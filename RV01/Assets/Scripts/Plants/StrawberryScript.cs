﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryScript : PlantScript
{
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        optimalHumidity = 0.7f;
        optimalIllumination = 0.7f;
        growthSpeed = 0.06f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}