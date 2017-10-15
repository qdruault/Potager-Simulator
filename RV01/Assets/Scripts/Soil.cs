using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour {

    // Type of the soil.
    protected string type;
    // Humidity of the soil.
    protected float humidityLevel;
    // How fast the soil dry.
    protected float drySpeed;

    private string Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

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
