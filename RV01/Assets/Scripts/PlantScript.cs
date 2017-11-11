using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour {

    // The soil if there is one.
    protected SoilScript soil = null;
    // The optimal level of humidity to grow.
    protected float optimalHumidity;
    // The growth speed.
    protected float growthSpeed;
    // The growth progress.
    protected float growthProgress = 0;
    // True if the plant is in the soil.
	protected bool isPlanted = false;

	protected Rigidbody rb;
	protected MeshRenderer rr;
    // The prefab of the grown plant.
	public GameObject plantPrefab;
	

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

    public float OptimalHumidity
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

    // Use this for initialization
	public virtual void Start () {
		rb = GetComponent<Rigidbody> ();
		rr = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	public virtual void Update ()
    {
        if (isPlanted)
        {
            // Make the plant grows.
            Grow();
            // When the growth is over.
            if (IsOver())
            {
                EndGrowth();
            }
        }
    }

    // The plant grows.
    protected void Grow()
    {
        // The values of humidity needed.
        float minHumidityRequired = this.optimalHumidity * 0.9f;
        float maxHumidityRequired = this.optimalHumidity * 1.1f;

        // If the soil is wet enough.
        if (this.soil.HumidityLevel > minHumidityRequired && this.soil.HumidityLevel < maxHumidityRequired)
        {
            this.growthProgress += this.growthSpeed;
            if (this.growthProgress > 1)
            {
                this.growthProgress = 1;
            }
        }
    }

    // Over ?
    protected bool IsOver()
    {
        return this.growthProgress >= 1;
    }

	protected void EndGrowth(){
        // The position of the future plant.
		Vector3 newPlantPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
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
            // The seed disappear (in the soil).
			rr.enabled = false;
            // The soil set to the plant is the object collided.
			soil = collision.gameObject.GetComponent<SoilScript>();
            // The seed is now planted.
			isPlanted = true;
		}
	}

}
