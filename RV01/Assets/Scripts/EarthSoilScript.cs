using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSoilScript : SoilScript {

	public GameObject dirtCubeModel;

	private float YThresholdUp;
	private float YThresholdDown;

	private bool emptyPot = false;
	private bool fullPot = false;

    private float minY;
    private float maxY;

    // Use this for initialization
    protected override void Start () {

        base.Start();

		YThresholdUp = transform.position.y;
		YThresholdDown = YThresholdUp - 0.1f;

		humidityLevel = 0f;
        drySpeed = 0.001f;

        minY = 1000000000;
        maxY = 1000000000;
    }

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	public void AddDirtCube(float pSize){
		if (!fullPot) {
			transform.Translate (new Vector3 (0, pSize / 10.0f, 0));
			if (emptyPot) {
				emptyPot = false;
			}
			if (transform.position.y >= YThresholdUp) {
				fullPot = true;
				Debug.Log ("ATTEINT");
			}
		}
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Shovel"))
        {
            if (other.gameObject.transform.position.y < minY)
            {
                minY = other.gameObject.transform.position.y;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shovel"))
        {
            maxY = other.gameObject.transform.position.y;
        }
    }

    void OnTriggerExit(Collider other) {

		if (!emptyPot) {

			// Si la pelle touche un sol
			if (other.gameObject.CompareTag ("Shovel")) {

                float cubeSize = maxY - minY;

                Vector3 basePosition = other.gameObject.transform.position;
				basePosition.y += 0.02f;
				Vector3 cubesPosition;

				//baisser le sol
				transform.Translate (new Vector3 (0, cubeSize / -10.0f, 0));
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
				GameObject cube = Instantiate (dirtCubeModel, cubesPosition, Quaternion.identity);
                cube.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

                /*
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
                */
                // Reset.
                minY = 1000000000;
                maxY = 1000000000;
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
