﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInputTest : MonoBehaviour {

    // 1: A reference to the object being tracked. In this case, a controller.
    private SteamVR_TrackedObject trackedObj;
    // 2: A Device property to provide easy access to the controller. It uses the tracked object’s index to return the controller’s input.
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Update is called once per frame
    void Update () {
        // 1: Get the position of the finger when it’s on the touchpad and write it to the Console.
        if (Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }

        // 2: When you squeeze the hair trigger, this line writes to the Console. 
        // The hair trigger has special methods to check whether it is pressed or not: 
        // GetHairTrigger(), GetHairTriggerDown() and GetHairTriggerUp()
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + " Trigger Press");
        }

        // 3: If you release the hair trigger, this if statement writes to the Console.
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + " Trigger Release");
        }

        // 4: If you press a grip button, this section writes to the Console.
        // Using the GetPressDown() method is the standard method to check if a button was pressed.
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Press");
        }

        // 5: When you release one of the grip buttons, this writes that action to the Console.
        // Using the GetPressUp() method is the standard way to check if a button was released.
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + " Grip Release");
        }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
}
