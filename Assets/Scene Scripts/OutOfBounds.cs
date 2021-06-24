using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update

    public Image img;
    void Start()
    {
        if(img.gameObject.activeSelf == true)
        {
            img.gameObject.SetActive(false);
        }

        Color startcol = img.color;
        startcol.a = 0f;

        img.color = startcol;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer != 8)
        {
            fadeIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.layer != 8)
        {
            fadeOut();
        }
    }



    public IEnumerator fadeIn()
    {
        img.gameObject.SetActive(true);

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }


        /*// loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
        img.gameObject.SetActive(false);*/
    }


    public IEnumerator fadeOut()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
        img.gameObject.SetActive(false);
    }
}
