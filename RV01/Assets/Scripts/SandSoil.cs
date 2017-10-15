using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandSoil : Soil {

	// Use this for initialization
	void Start () {
        this.humidityLevel = 0.05f;
        this.drySpeed = 0.01f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
