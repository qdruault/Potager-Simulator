using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : PlantScript {

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        //this.optimalHumidity = 0.7f;
        optimalHumidity = 1f;
        this.growthSpeed = 0.005f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
