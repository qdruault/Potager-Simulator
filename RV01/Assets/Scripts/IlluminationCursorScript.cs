using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluminationCursorScript : MonoBehaviour {

	// Bounds of the cursor.
	private float minY;
	private float maxY;

	// Illumination value: 0 = dark / 1 = bright.
	private float illumination;

	// Use this for initialization
	void Start () {
		// Get the bounds relative to the Rail position and size.
		Transform railTransform = GameObject.Find("IRail").transform;
		minY = railTransform.position.x - railTransform.localScale.x / 2 + transform.localScale.x;
		maxY = railTransform.position.x + railTransform.localScale.x / 2 - transform.localScale.x;

		// Init Illumination.
		illumination = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		// Block the slider.
		if(transform.position.x <= minY)
		{
			transform.position = new Vector3(minY, transform.position.y, transform.position.z);
		} else if (transform.position.x >= maxY)
		{
			transform.position = new Vector3(maxY, transform.position.y, transform.position.z);
		}

		// Stop the move.
		GetComponent<Rigidbody>().velocity = Vector3.zero;

		// Update the temperature value.
		illumination = (transform.position.x - maxY) / (minY - maxY);
	}

	public float Illumination
	{
		get
		{
			return illumination;
		}
	}
}
