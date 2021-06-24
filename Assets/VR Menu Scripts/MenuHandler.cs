using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objectToDisable;

    private bool isEnabled = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.Four))
        {
            isEnabled = true;
        }
        if(OVRInput.Get(OVRInput.Button.Three))
        {
            isEnabled = false;
        }
    }

    private void FixedUpdate()
    {
        if(isEnabled)
        {
            objectToDisable.SetActive(true);
        }
        if(!isEnabled)
        {
            objectToDisable.SetActive(false);
        }
    }
}
