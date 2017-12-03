using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Shovel"))
		{
			transform.parent.gameObject.transform.GetChild (0).GetComponent<BoxCollider> ().isTrigger = true;
		}

	}

	void OnTriggerExit(Collider other) {

		if (other.gameObject.CompareTag ("Shovel"))
		{
			transform.parent.gameObject.transform.GetChild (0).GetComponent<BoxCollider> ().isTrigger = false;
		}

	}
}
