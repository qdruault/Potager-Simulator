using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

    // The soil if there is one.
    protected Soil soil = null;
    // The optimal level of humidity to grow.
    protected float optimalHumidity;
    // The growth speed.
    protected float growthSpeed;
    // The growth progress.
    protected float growthProgress = 0;

	protected bool isPlanted = false;

	protected Rigidbody rb;
	protected MeshRenderer rr;

	public GameObject apple;
	

    public Soil Soil
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
	public virtual void Update () {
	}

    // The plant grows.
    protected void Grow()
    {
        // The values of humidity needed.
        float minHumidityRequired = this.optimalHumidity * 0.9f;
        float maxHumidityRequired = this.optimalHumidity * 1.1f;

		Debug.Log ("Humidity : " + this.soil.HumidityLevel);
		Debug.Log ("Min : " + minHumidityRequired);
		Debug.Log ("Max : " + maxHumidityRequired);

        // If the soil is wet enough.
        if (this.soil.HumidityLevel > minHumidityRequired && this.soil.HumidityLevel < maxHumidityRequired)
        {
            this.growthProgress += this.growthSpeed;
			Debug.Log ("Grow Progress : " + this.growthProgress);
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
		isPlanted = false;
		Vector3 applePosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Instantiate (apple, applePosition, Quaternion.identity);
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision collision){

		// Drop on soil
		if (collision.gameObject.CompareTag ("Soil")) {
			Debug.Log ("Soil");
			// indication graphique
			gameObject.transform.position = collision.gameObject.transform.position;

			rr.enabled = false;

			soil = collision.gameObject.GetComponent<Soil>();

			isPlanted = true;
		}
	}

}
