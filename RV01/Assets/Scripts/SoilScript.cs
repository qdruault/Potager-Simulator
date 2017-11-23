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

    // The material to darken when the soil is wet.
    private Material material;

    // Use this for initialization
    protected virtual void Start () {
        material = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        Dry();
        UpdateMaterial();
	}

    /** Water the soil.
     * water : float between 0.0f and 1.0f
     * */
    public virtual void Water(float water)
    {		
        humidityLevel += water;
        if (humidityLevel > 1)
        {
            humidityLevel = 1;
        }
		Debug.Log ("humidity level : " + humidityLevel);
    }

    // The soils dries.
    private void Dry()
    {
        // Get the current temperature.
        float temperature = GameObject.Find("Cursor").GetComponent<CursorScript>().Temperature;
        // The warmer the faster.
        humidityLevel -= drySpeed * temperature;
        if (humidityLevel < 0)
        {
            humidityLevel = 0;
        }
    }

    private void UpdateMaterial()
    {
        // Darken if the floor is wet.
        material.SetFloat("_Metallic", humidityLevel);
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

	protected Material Material
	{
		get
		{
			return material;
		}

		set
		{
			material = value;
		}
	}
}
