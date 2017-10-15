using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour {

    private enum SoilType { Earth, Sand };

    private float humidityLevel;
    private SoilType type;

    private SoilType Type
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
}
