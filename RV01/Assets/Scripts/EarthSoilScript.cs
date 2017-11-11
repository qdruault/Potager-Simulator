﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSoilScript : SoilScript {

	public GameObject dirtCubeModel;


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

	void OnTriggerExit(Collider other) {

		Debug.Log (gameObject.name);
		Debug.Log ("Dans le trigger exit");

		Debug.Log (other.gameObject.name);

		// Si la pelle touche un sol
		if (other.gameObject.CompareTag("Shovel")){

			Debug.Log ("Dans le if soil");

			Vector3 basePosition = other.gameObject.transform.position;
			basePosition.y += 0.02f;
			Vector3 cubesPosition;

			//baisser le sol

			// Crée les petits cubes de terre
			cubesPosition = basePosition;
			cubesPosition.x += 0.05f;
			cubesPosition.z += 0.05f;
			Instantiate(dirtCubeModel, cubesPosition, Quaternion.identity);

			cubesPosition = basePosition;
			cubesPosition.x -= 0.05f;
			cubesPosition.z -= 0.05f;
			Instantiate(dirtCubeModel, cubesPosition, Quaternion.identity);

			cubesPosition = basePosition;
			cubesPosition.x += 0.05f;
			cubesPosition.z -= 0.05f;
			Instantiate(dirtCubeModel, cubesPosition, Quaternion.identity);

			cubesPosition = basePosition;
			cubesPosition.x -= 0.05f;
			cubesPosition.z += 0.05f;
			Instantiate(dirtCubeModel, cubesPosition, Quaternion.identity);

			cubesPosition = basePosition;
			Instantiate(dirtCubeModel, cubesPosition, Quaternion.identity);
		}
	}


}
