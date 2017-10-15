using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

    // The soil if there is one.
    protected Soil soil;
    // The optimal level of humidity to grow.
    protected float optimalHumidity;

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

    // Use this for initialization
    void Start () {
        this.Soil = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
