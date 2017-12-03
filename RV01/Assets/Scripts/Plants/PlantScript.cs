using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Humidity { Dry, Normal, Wet, VeryWet };
public enum Temperature { Cold, Fresh, Temperate, Hot };

public class PlantScript : MonoBehaviour {

    // The soil if there is one.
    protected SoilScript soil = null;
    // The optimal level of humidity to grow.
    protected Humidity optimalHumidity;
    // The optimal temperature to grow.
    protected Temperature optimalTemperature;
    // The growth speed.
    protected float growthSpeed;
    // The growth progress.
    protected float growthProgress = 0;
    // True if the plant is in the soil.
	protected bool isPlanted = false;

	protected Rigidbody rb;
	protected MeshRenderer rr;

	private EarthSoilScript earthSoil = null;

	private SphereCollider sc;

    // The prefab of the grown plant.
	public GameObject plantPrefab;

	// Illumination
	protected float optimalIllumination;


     // Use this for initialization
	public virtual void Start () {
		rb = GetComponent<Rigidbody> ();
		rr = GetComponent<MeshRenderer> ();
		sc = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	public virtual void Update ()
    {
        if (isPlanted)
        {
			if (earthSoil.FullPot) {
				// Make the plant grows.
				Grow ();
				// When the growth is over.
				if (IsOver ()) {
					EndGrowth ();
				}
			}
        }
    }

    // The plant grows.
    protected void Grow()
    {
        Debug.Log(growthProgress);

		// MinIllumination
		float minIllumination = optimalIllumination * 0.9f;
		// Get the current illumination.
		float currentIllumination = GameObject.Find("CursorI").GetComponent<ICursorScript>().Illumination;
        // Get the current temperature.
        Temperature currentTemperature = GameObject.Find("CursorT").GetComponent<TCursorScript>().Temperature;

        Debug.Log("Illumination. Needed : " + minIllumination + " réelle : " + currentIllumination);
        Debug.Log("Humidity. Needed : " + optimalHumidity + " réelle : " + soil.Humidity);
        Debug.Log("Temperature. Needed : " + OptimalTemperature + " réelle : " + currentTemperature);

        // If the soil is wet enough and there is enough light and ther is the riht temperature.
        if (soil.Humidity == optimalHumidity && currentIllumination >= minIllumination && currentTemperature == optimalTemperature)
        {
            growthProgress += growthSpeed;
            if (growthProgress > 1)
            {
                growthProgress = 1;
            }
        } else
        {
            //TODO: ajouter les malus ici.
        }
    }

    // Over ?
    protected bool IsOver()
    {
        return growthProgress >= 1;
    }

	protected void EndGrowth(){

		float Ypos = earthSoil.getYThresholdUp;

        // The position of the future plant.
		Vector3 newPlantPosition = new Vector3 (transform.position.x, Ypos + 1, transform.position.z);
        // Create the plant at the right spot using the right prefab.
		GameObject newPlant = Instantiate (plantPrefab, newPlantPosition, Quaternion.identity);
        // Few fixes to be able to "take" the new plant.
        newPlant.tag = "Draggable";
        newPlant.AddComponent<Rigidbody>();
        // Destroy the "seed".
        Destroy (gameObject);
	}

	void OnCollisionEnter(Collision collision){

		// When the seed is "planted".
		if (collision.gameObject.CompareTag ("Soil")) {

			if (collision.gameObject.GetComponent<EarthSoilScript> ().EmptyPot) {
				// The seed disappear (in the soil).
				//rr.enabled = false;
				// The soil set to the plant is the object collided.
				soil = collision.gameObject.GetComponent<SoilScript> ();

				earthSoil = collision.gameObject.GetComponent<EarthSoilScript> ();

				rb.isKinematic = true;
				sc.isTrigger = true;

				// The seed is now planted.
				isPlanted = true;
			}
		}
	}


	public SoilScript Soil
	{
		get
		{
			return soil;
		}

		set
		{
			soil = value;
		}
	}

	public Humidity OptimalHumidity
	{
		get
		{
			return optimalHumidity;
		}

		set
		{
			optimalHumidity = value;
		}
	}

    public Temperature OptimalTemperature
    {
        get
        {
            return optimalTemperature;
        }

        set
        {
            optimalTemperature = value;
        }
    }

    public float OptimalIllumination
	{
		get
		{
			return optimalIllumination;
		}

		set
		{
			optimalIllumination = value;
		}
	}

	public float GrowthSpeed
	{
		get
		{
			return growthSpeed;
		}

		set
		{
			growthSpeed = value;
		}
	}

	public float GrowthProgress
	{
		get
		{
			return growthProgress;
		}

		set
		{
			growthProgress = value;
		}
	}

}
