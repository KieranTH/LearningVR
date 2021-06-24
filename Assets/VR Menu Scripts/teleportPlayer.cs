using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleportPlayer : MonoBehaviour
{
    //--- teleport points in scene ---
    private Transform roman;
    private Transform pirate;
    private Transform ww;

	//--- black image ---
    public Image img;
    private float alpha;
    private float rate = 0.2f;
    private bool done = false;

	//--- player object ---
    public GameObject player;
	
	//--- on program start ---
    void Start()
    {
		//--- setting children ---
        roman = gameObject.transform.GetChild(0);
        pirate = gameObject.transform.GetChild(1);
        ww = gameObject.transform.GetChild(2);
		
		//--- error checking ---
        if(img == null)
        {
            Debug.Log("No Fade Image found");
        }

		//--- disabling object by default ---
        img.gameObject.SetActive(false);


		//--- default alpha ---
        alpha = 0f;


		//--- storing starting image ---
        Color startcol = img.color;
        startcol.a = 0f;
	
	
		//--- setting alpha to 0 ---
        img.color = startcol;
        
    }


	//--- if roman button is clicked ---
    public void romanButton()
    {
        Debug.Log("Roman Teleport");
        StartCoroutine(fadeIn("roman"));
    }
	
	
	//--- if pirate button is clicked ---
    public void pirateButton()
    {
        Debug.Log("Roman Teleport");
        StartCoroutine(fadeIn("pirate"));
    }
	
	//--- if WW button is clicked ---
    public void wwButton()
    {
        Debug.Log("Roman Teleport");
        StartCoroutine(fadeIn("ww"));
    }


	//--- exit button ---
    public void exitButton()
    {
        Application.Quit();
    }



	//--- telport player to roman area ---
    public void romanTeleport()
    {
        player.transform.position = roman.position;
    }


	//--- teleport player to pirate area ---
    public void pirateTeleport()
    {
        player.transform.position = pirate.position;
    }


	//--- teleport player to WW area ---
    public void wwTeleport()
    {
        player.transform.position = ww.position;
    }


	//--- transition Enum ---
    public IEnumerator fadeIn(string buttonName)
    {
		//--- enabling image ---
        img.gameObject.SetActive(true);


		//--- fading in image ---
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
		
		//--- waiting 1 second ---
        yield return new WaitForSeconds(1);
		
		//--- teleporting player ---
        if (buttonName.Equals("roman"))
        {
            romanTeleport();
        }
        else if (buttonName.Equals("pirate"))
        {
            pirateTeleport();
        }
        else if (buttonName.Equals("ww"))
        {
            wwTeleport();
        }
        

		//--- fading out image ---
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
		
		//--- disabling image ---
        img.gameObject.SetActive(false);
    }
}
