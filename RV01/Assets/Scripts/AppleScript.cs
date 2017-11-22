using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : PlantScript {

	// Use this for initialization
	public override void Start () {

		base.Start ();
		optimalHumidity = 1f;
        //this.optimalHumidity = 0.4f;
        growthSpeed = 0.01f;

		optimalIllumination = 1f;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update ();
	}

}
