using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Plant {

	// Use this for initialization
	void Start () {
        this.optimalHumidity = 0.4f;
        this.growthSpeed = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
        this.Grow();
        if (this.IsOver())
        {
            Debug.Log("Here's a apple!");
        }
	}
}
