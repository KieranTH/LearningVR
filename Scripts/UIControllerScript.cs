/****
*
*	File: UIControllerScript.cs - Script to control aspects of UI within scene
*
*	Author: Kieran Hughes
*
*	Date: 2021
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
	//--- objects ---
    private GameObject child;
    public GameObject obj;
	
	//--- text canvas ---
    public Transform canvas;
    private bool inside;
    // Start is called before the first frame update
    void Start()
    {
		//--- default ---
        inside = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       
		//--- if object inside activate ---
        if(inside)
        {
            obj.SetActive(true);
        }
		//--- else deactivate ---
        else
        {
            obj.SetActive(false);
        }

       
    }
	
	
	//--- if object in hand ---
    private void OnTriggerEnter(Collider other)
    {
		//--- enable text ---
        if(other.gameObject.name == "DistanceGrabHandLeft" || other.gameObject.name == "DistanceGrabHandRight")
        {
            inside = true;
        }
		//--- fade text if too close ---
        if (other.gameObject.name == "ComfortZoneDetection")
        {
            Debug.Log("Entered Comfort Zone");
            StartCoroutine(FadeTextToZeroAlpha(1f, canvas.GetComponentInChildren<Text>()));
        }

    }

	//--- if not in hand or too close ---
    private void OnTriggerExit(Collider other)
    {
		//--- disable text ---
        if (other.gameObject.name == "DistanceGrabHandLeft" || other.gameObject.name == "DistanceGrabHandRight")
        {
            inside = false;
        }

		//--- unfade text ---
        if(other.gameObject.name == "ComfortZoneDetection")
        {
            Debug.Log("Exit Comfort Zone");
            StartCoroutine(FadeTextToFullAlpha(1f, canvas.GetComponentInChildren<Text>()));
        }
    }
	
	
	//--- fading in Enum ---
    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

	//--- fading out Enum
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

}
