using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPointer : MonoBehaviour
{
    public float dLength = 3.0f; //--- line length ---

    //--- line ---
    private LineRenderer lineRenderer = null;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLength();
    }

    /// <summary>
    /// Update length of line rendered
    /// </summary>
    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, calPoint());
    }

    /// <summary>
    /// Calculate point where line hit object
    /// </summary>
    /// <returns></returns>
    private Vector3 calPoint()
    {
        RaycastHit hit = forwardRay();
        Vector3 endPos = end(dLength);

        if(hit.collider)
        {
            endPos = hit.point;
        }
        return endPos;
    }

    /// <summary>
    /// Creating raycast for line
    /// </summary>
    /// <returns></returns>
    private RaycastHit forwardRay()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, dLength);

        return hit;
    }

    private Vector3 end(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
