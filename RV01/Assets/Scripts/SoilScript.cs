using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilScript : MonoBehaviour {

    // Humidity of the soil.
    protected float humidityLevel;
    // How fast the soil dry.
    protected float drySpeed;
    // The plant if there is one.
    protected PlantScript plant = null;

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

    public PlantScript Plant
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
	protected virtual void Start () {
        
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        //this.Dry();
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
    private void Dry()
    {
        this.humidityLevel -= drySpeed;
        if (this.humidityLevel < 0)
        {
            this.humidityLevel = 0;
        }
    }
}
