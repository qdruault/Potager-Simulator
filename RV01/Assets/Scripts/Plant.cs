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
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
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
}
