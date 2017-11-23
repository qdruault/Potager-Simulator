using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetScript : PlantScript {

	// Use this for initialization
	public override void Start () {

		base.Start ();
        optimalHumidity = 0.5f;
        optimalIllumination = 0.8f;
        growthSpeed = 0.001f;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update ();
	}

}
