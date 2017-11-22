using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropScript : MonoBehaviour {

	private float waterValue = 0.002f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Soil")) {
			other.gameObject.GetComponent<SoilScript> ().Water (waterValue);
			Destroy (gameObject);
		}
	}

	/*void OnCollisionEnter(Collision other) {
		if (!other.gameObject.CompareTag ("WaterDrop")) {
			Destroy (gameObject);
		}
	}*/
}
