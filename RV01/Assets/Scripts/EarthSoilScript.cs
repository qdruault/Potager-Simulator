using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSoilScript : SoilScript
{
	// Use this for initialization
	protected override void Start () {

        base.Start();

        this.humidityLevel = 1f;
        //this.humidityLevel = 0.3f;
        this.drySpeed = 0.001f;
    }
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}
}
