using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour {

	public GameObject dirtCubeModel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider other) {

		Debug.Log (gameObject.name);
		Debug.Log ("Dans le trigger exit");

		Debug.Log (other.gameObject.name);

		// Si la pelle touche un sol
		if (other.gameObject.CompareTag("Soil")){

			Debug.Log ("Dans le if soil");
	
			Vector3 basePosition = transform.position;
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
