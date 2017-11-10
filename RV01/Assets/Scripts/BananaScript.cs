using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : PlantScript {

    // Use this for initialization
    void Start()
    {
        this.optimalHumidity = 0.7f;
        this.growthSpeed = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        this.Grow();
        if (this.IsOver())
        {
            Debug.Log("Here's a banana!");
        }
    }
}
