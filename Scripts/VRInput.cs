/****
*
*	File: VRInput.cs - Script to pass VR Controls within Unity
*
*	Author: Kieran Hughes
*
*	Date: 2021
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRInput : BaseInput
{
    //--- camera for cursour placement ---
    public Camera eventCamera = null;

    //--- inputs from user controller ---
    public OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;
    public OVRInput.Controller controller = OVRInput.Controller.All;

    /// <summary>
    /// Overriding BaseInput Event System from Unity
    /// </summary>
    protected override void Awake()
    {
        GetComponent<BaseInputModule>().inputOverride = this;
    }

    /// <summary>
    /// Method for triggering mouse click from Controller
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public override bool GetMouseButton(int button)
    {
        return OVRInput.Get(clickButton, controller);
    }

    /// <summary>
    /// Mouse click down from User
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public override bool GetMouseButtonDown(int button)
    {
        return OVRInput.GetDown(clickButton, controller);
    }

    /// <summary>
    /// Mouse click up from user
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public override bool GetMouseButtonUp(int button)
    {
        return OVRInput.GetUp(clickButton, controller);
    }

    /// <summary>
    /// Getting position of click
    /// </summary>
    public override Vector2 mousePosition
    {
        get
        {
            ///---- getting centre of camera as pixel ---
            return new Vector2(eventCamera.pixelWidth / 2, eventCamera.pixelHeight / 2);
        }
    }
}
