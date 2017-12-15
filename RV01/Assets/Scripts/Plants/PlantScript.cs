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
    // Malus.
    protected int penalties;
    // Current game difficulty.
    protected Difficulty gameDifficulty;

    protected Rigidbody rb;
	protected MeshRenderer rr;

	private EarthSoilScript earthSoil = null;

	private SphereCollider sc;

    // The prefab of the grown plant.
	public GameObject plantPrefab;

    // The prefab of the failed plant.
    public GameObject failPrefab;

    // Illumination
    protected float optimalIllumination;


     // Use this for initialization
	public virtual void Start () {
        penalties = 0;
		rb = GetComponent<Rigidbody> ();
		rr = GetComponent<MeshRenderer> ();
		sc = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	public virtual void Update ()
    {
        // Get the current game difficulty.
        gameDifficulty = GameObject.Find("ControlPannel").GetComponent<DifficultyScript>().GameDifficulty;

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
        Debug.Log("Progress: " + growthProgress);

        // MinIllumination
        float minIllumination = optimalIllumination * 0.9f;
		// Get the current illumination.
		float currentIllumination = GameObject.Find("CursorI").GetComponent<ICursorScript>().Illumination;
        // Get the current temperature.
        Temperature currentTemperature = GameObject.Find("CursorT").GetComponent<TCursorScript>().Temperature;

        Debug.Log("Illumination. Needed : " + minIllumination + " réelle : " + currentIllumination);
        Debug.Log("Humidity. Needed : " + optimalHumidity + " réelle : " + soil.Humidity);
        Debug.Log("Temperature. Needed : " + OptimalTemperature + " réelle : " + currentTemperature);

        // If the soil is wet enough.
        if (soil.Humidity == optimalHumidity)
        {
            // Except for Easy mode, check if there is enough light and there is the right temperature.
            if (gameDifficulty == Difficulty.Easy || currentIllumination >= minIllumination && currentTemperature == optimalTemperature)
            {
                growthProgress += growthSpeed;
                if (growthProgress > 1)
                {
                    growthProgress = 1;
                }
            }
            
        } else
        {
            // Ignore the malus il the plant has just been planted.
            // Just for hard mode.
            if (gameDifficulty == Difficulty.Hard && growthProgress > 0)
            {
                penalties++;
            }
        }
    }

    public void AddPenalties()
    {
        // Just fir hard mode.
		if (gameDifficulty == Difficulty.Hard && isPlanted) {
			penalties++;
		}
    }

    // Over ?
    protected bool IsOver()
    {
        return growthProgress >= 1;
    }

	protected void EndGrowth(){

        Debug.Log("Nombre de malus: " + penalties);

		float Ypos = earthSoil.getYThresholdUp;

        // The position of the future plant.
        Vector3 newPlantPosition = new Vector3(transform.position.x, Ypos + 1, transform.position.z);

        GameObject newPlant;

        // Good
        if (penalties < 200)
        {
            // Create the plant at the right spot using the right prefab.
            newPlant = Instantiate(plantPrefab, newPlantPosition, Quaternion.identity);

            // Perfect if < 100
            if (penalties > 100)
            {
                newPlant.transform.localScale = new Vector3(-0.008f * penalties + 1.8f, -0.008f * penalties + 1.8f, -0.008f * penalties + 1.8f);
            }
        } else
        {
            // Failed.
            newPlant = Instantiate(failPrefab, newPlantPosition, Quaternion.identity);
            newPlant.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }

        // Few fixes to be able to "take" the new plant.
        newPlant.tag = "Draggable";
        newPlant.AddComponent<Rigidbody>();
        // Destroy the "seed".
        Destroy(gameObject);

        // Scenario.
        // 1st step OK.
        if (gameDifficulty == Difficulty.Easy)
        {
            // TODO: Faire une UI jolie.
            Debug.Log("Bravo ! Maintenant attention, il faut aussi prendre en compte la luminosité et la température. A vous de jouer !");
            // Change difficulty.
            GameObject.Find("ControlPannel").GetComponent<DifficultyScript>().GameDifficulty = Difficulty.Normal;
            Debug.Log(GameObject.Find("ControlPannel").GetComponent<DifficultyScript>().GameDifficulty);
        }
        // 2nd step OK.
        else if (gameDifficulty == Difficulty.Normal)
        {
            // TODO: Faire une UI jolie.
            Debug.Log("Vous avez la main verte à ce que je vois. Concentrez vous pour rester le plus possible dans des conditions optimales de poussée sinon votre plante sera de moindre qualité. Pensez à arracher les mauvaises herbes qui poussent et espacez suffisamment vos graines !");
            // Change difficulty.
            GameObject.Find("ControlPannel").GetComponent<DifficultyScript>().GameDifficulty = Difficulty.Hard;
        }
        else if (gameDifficulty == Difficulty.Hard)
        {
            // TODO: Faire une UI jolie.
            Debug.Log("Vous venez de faire pousser votre première plante dans des conditions réelles ! Vous pouvez continuer à vous amuser.");
        }

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

    public bool IsPlanted
    {
        get
        {
            return isPlanted;
        }
    }

    }
