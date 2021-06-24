/****
*
*	File: FreezeObject.cs - Script to Freeze objects within scene
*
*	Author: Kieran Hughes
*
*	Date: 2021
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObject : MonoBehaviour
{
	//--- current object ---
    public Rigidbody rigid;
	
	//--- checking vars ---
    private bool isButtonPressed = false;
    private bool inZone = false;
    
	//--- starting program ---
    void Start()
    {
		//--- getting rigidbody ---
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		//--- if controller button pressed ---
        if (OVRInput.Get(OVRInput.Button.Two))
        {
			//--- freeze object ---
            isButtonPressed = true;
        }
		//--- release object ---
        if(OVRInput.Get(OVRInput.Button.One))
        {
            isButtonPressed = false;
        }
    }

    //--- if collision is detected ---
    private void OnCollisionEnter(Collision collision)
    {
		//--- in freeze zone ---
        inZone = true;
    }

	//--- if not in zone ---
    private void OnCollisionExit(Collision collision)
    {
        inZone = false;
    }


	//--- if holding and button pressed, freeze object ---
    private void FixedUpdate()
    {
        if(isButtonPressed && inZone == false)
        {
            rigid.isKinematic = true;
            
        }
    }
}
