using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishScript : PlantScript {

    // Use this for initialization
    public override void Start()
    {

        base.Start();
        optimalHumidity = 0.4f;
        optimalIllumination = 0.8f;
        growthSpeed = 0.1f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
