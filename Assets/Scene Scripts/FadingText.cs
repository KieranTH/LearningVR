using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingText : MonoBehaviour
{
	
	//--- canvas object ---
    Transform canvas;
    
	//--- program start ---
    void Start()
    {
		//--- find canvas object ---
        canvas = transform.Find("Canvas");
        
    }


	//--- checking collision of ComfortZone collider ---
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("ComfortZone"))
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, canvas.GetComponentInChildren<Text>()));
        }
    }


	//--- checking if exit of collider ---
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag.Equals("ComfortZone"))
        {
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


	//--- fading out Enum ---
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
