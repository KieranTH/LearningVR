using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClicking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickButton()
    {
        if(gameObject.name.Equals("pirateB"))
        {
            Debug.Log("Clicked Pirate");
        }
        if(gameObject.name.Equals("romanB"))
        {

        }
        if(gameObject.name.Equals("WWB"))
        {

        }
        if(gameObject.name.Equals("exitB"))
        {

        }
        
    }
}
