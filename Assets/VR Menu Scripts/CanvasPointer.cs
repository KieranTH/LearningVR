using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasPointer : MonoBehaviour
{
    public float dLength = 3.0f; //--- line length ---

	//--- Canvas Event System ---
    public EventSystem eventSystem = null;

	//--- VR input ---
    public StandaloneInputModule inputModule = null;

    //--- line ---
    private LineRenderer lineRenderer = null;

	//--- starting method ---
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

	//--- update length per frame ---
    private void Update()
    {
        UpdateLength();
    }

    //--- updating line length depending on collider ---
    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, GetEnd());
    }


	//--- calculating laser length ---
    private Vector3 GetEnd()
    {

        float dist = getCanvasDistance();

        Vector3 endpos = CalEnd(dLength);

        if(dist != 0.0f)
        {
            endpos = CalEnd(dist);
        }

        return endpos;
    }


	//--- getting Canvas distance ---
    private float getCanvasDistance()
    {
		//--- raycast collision data ---
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = inputModule.inputOverride.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
		
		//--- storing all raycast collisions ---
        eventSystem.RaycastAll(eventData, results);

		//--- getting closest collision ---
        RaycastResult closestRes = findFirstRaycast(results);
        float dist = closestRes.distance;


		//--- distance from collision ---
        dist = Mathf.Clamp(dist, 0.0f, dLength);

        return dist;
    }
	
	
	//--- filtering raycasts ---
    private RaycastResult findFirstRaycast(List<RaycastResult> results)
    {
        foreach(RaycastResult result in results)
        {
            if(!result.gameObject)
            {
                continue;
            }

            return result;
        }

        return new RaycastResult();
    }

    private Vector3 CalEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
