using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaikonScript : PlantScript
{
    // Use this for initialization
    public override void Start()
    {

        base.Start();
        optimalHumidity = 0.8f;
        optimalIllumination = 0.5f;
        growthSpeed = 0.008f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
