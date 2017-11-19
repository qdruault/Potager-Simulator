using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

    // Bounds of the cursor.
    private float minX;
    private float maxX;


    // Use this for initialization
    void Start () {
        // Get the bounds relative to the Rail position and size.
        Transform railTransform = GameObject.Find("Rail").transform;
        minX = railTransform.position.x - railTransform.localScale.x / 2 + transform.localScale.x / 2;
        maxX = railTransform.position.x + railTransform.localScale.x / 2 - transform.localScale.x / 2;
    }
	
	// Update is called once per frame
	void Update () {
        // Block the slider.
        if(transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        } else if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
    }
}
