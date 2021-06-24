using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockChildRotation : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        //--- following centre camera of user ---
        Transform newCam = Camera.main.transform;
		
		//--- finding rotation for camera ---
        newCam.transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y*-1, Camera.main.transform.rotation.z);
		
		//--- looking at user camera ---
        transform.LookAt(newCam.transform);
        
    }
}
