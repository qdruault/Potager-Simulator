using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSoilScript : SoilScript {

	public GameObject dirtCubeModel;

	private float YThresholdUp;
	private float YThresholdDown;

	private bool emptyPot = false;
	private bool fullPot = false;

	// Use this for initialization
	protected override void Start () {

        base.Start();

		YThresholdUp = transform.position.y;
		YThresholdDown = YThresholdUp - 0.15f;

		this.humidityLevel = 0f;
        //this.humidityLevel = 0.3f;
        this.drySpeed = 0.001f;
    }

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	public void addDirtCube(){
		if (!fullPot) {
			transform.Translate (new Vector3 (0, 0.01f, 0));
			if (emptyPot) {
				emptyPot = false;
			}
			if (transform.position.y >= YThresholdUp) {
				fullPot = true;
				Debug.Log ("ATTEINT");
			}
		}
	}

	/*void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("DirtCube")) {
			Destroy (other.gameObject);
			addDirtCube ();
		}
	}*/

	void OnTriggerExit(Collider other) {

		if (!emptyPot) {

			// Si la pelle touche un sol
			if (other.gameObject.CompareTag ("Shovel")) {

				Vector3 basePosition = other.gameObject.transform.position;
				basePosition.y += 0.02f;
				Vector3 cubesPosition;

				//baisser le sol
				transform.Translate (new Vector3 (0, -0.05f, 0));
				if (fullPot) {
					fullPot = false;
				}
				if (transform.position.y <= YThresholdDown) {
					emptyPot = true;
					Debug.Log ("ATTEINT");
				}

				// Crée les petits cubes de terre
				cubesPosition = basePosition;
				cubesPosition.x += 0.05f;
				cubesPosition.z += 0.05f;
				Instantiate (dirtCubeModel, cubesPosition, Quaternion.identity);

				cubesPosition = basePosition;
				cubesPosition.x -= 0.05f;
				cubesPosition.z -= 0.05f;
				Instantiate (dirtCubeModel, cubesPosition, Quaternion.identity);

				cubesPosition = basePosition;
				cubesPosition.x += 0.05f;
				cubesPosition.z -= 0.05f;
				Instantiate (dirtCubeModel, cubesPosition, Quaternion.identity);

				cubesPosition = basePosition;
				cubesPosition.x -= 0.05f;
				cubesPosition.z += 0.05f;
				Instantiate (dirtCubeModel, cubesPosition, Quaternion.identity);

				cubesPosition = basePosition;
				Instantiate (dirtCubeModel, cubesPosition, Quaternion.identity);
			}
		}
	}
		
	public override void Water(float water){
		Debug.Log ("water");
		base.Water (water);
	}	

	public bool EmptyPot
	{
		get
		{
			return emptyPot;
		}
	}

	public bool FullPot
	{
		get
		{
			return fullPot;
		}
	}

	public float getYThresholdUp
	{
		get
		{
			return YThresholdUp;
		}
	}

}
