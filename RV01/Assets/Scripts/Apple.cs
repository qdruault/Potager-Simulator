using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Plant {

	// Use this for initialization
	public override void Start () {

		base.Start ();

		this.optimalHumidity = 1f;
        //this.optimalHumidity = 0.4f;
        this.growthSpeed = 0.01f;
	}
	
	// Update is called once per frame
	public override void Update () {

		//Debug.Log ("Dans le Update");

		base.Update ();

		if (isPlanted) {

			Debug.Log ("Dans le isPlanted");

			this.Grow ();
			if (this.IsOver ()) {
				Debug.Log ("Here's an apple!");
				EndGrowth ();
			}
		}
	}

}
