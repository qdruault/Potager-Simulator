using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Trigger de la pelle : " + transform.GetChild (4).gameObject.GetComponent<BoxCollider> ().isTrigger);
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Soil") || collision.gameObject.CompareTag("Mold")) {
			transform.GetChild (0).gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			transform.GetChild (1).gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			transform.GetChild (2).gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			transform.GetChild (3).gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			transform.GetChild (4).gameObject.GetComponent<BoxCollider> ().isTrigger = true;
		}
	}
}
