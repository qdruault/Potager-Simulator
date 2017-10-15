using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSoil : Soil {

	// Use this for initialization
	void Start () {
        this.humidityLevel = 0.3f;
        this.drySpeed = 0.001f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
