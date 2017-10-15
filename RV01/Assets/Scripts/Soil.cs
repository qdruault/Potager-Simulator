using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour {

    // Humidity of the soil.
    protected float humidityLevel;
    // How fast the soil dry.
    protected float drySpeed;
    // The plant if there is one.
    protected Plant plant = null;

    public float HumidityLevel
    {
        get
        {
            return humidityLevel;
        }

        set
        {
            humidityLevel = value;
        }
    }

    public Plant Plant
    {
        get
        {
            return plant;
        }

        set
        {
            plant = value;
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /** Water the soil.
     * water : float between 0.0f and 1.0f
     * */
    public void Water(float water)
    {
        this.humidityLevel += water;
        if (this.humidityLevel > 1)
        {
            this.humidityLevel = 1;
        }
    }

    // The soils dries.
    public void Dry()
    {
        this.humidityLevel -= drySpeed;
        if (this.humidityLevel < 0)
        {
            this.humidityLevel = 0;
        }
    }
}
