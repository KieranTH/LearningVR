using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererScript : MonoBehaviour
{
    [SerializeField] LineRenderer rend;

    Vector3[] points;


    public LayerMask layerMask;

    public GameObject panel;
    public Image img;
    public Button btn;


    private void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();

        points = new Vector3[2];

        points[0] = Vector3.zero;

        points[1] = transform.position + new Vector3(0, 0, 20);

        rend.SetPositions(points);
        rend.enabled = true;

        img = panel.GetComponent<Image>();
    }

    public bool AlignRenderer(LineRenderer rend)
    {
        bool hitBtn = false;
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            rend.startColor = Color.red;
            rend.endColor = Color.red;
            btn = hit.collider.gameObject.GetComponent<Button>();
            hitBtn = true;
        }
        else
        {
            points[1] = transform.position + new Vector3(0, 0, 50);
            rend.startColor = Color.red;
            rend.endColor = Color.red;
            hitBtn = false;
        }

        rend.SetPositions(points);
        rend.material.color = rend.startColor;
        return hitBtn;
    }

    private void Update()
    {
        //AlignRenderer(rend);
        if(AlignRenderer(rend) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            btn.onClick.Invoke();
        }
    }

    public void ChangeOnClick()
    {
        if(btn != null)
        {
            if(btn.name == "red_btn")
            {
                img.color = Color.red;
                Debug.Log("Red");
            }
            else if(btn.name =="blue_btn")
            {
                img.color = Color.blue;
                Debug.Log("Blue");
            }
            else if(btn.name =="green_btn")
            {
                img.color = Color.green;
                Debug.Log("Green");
            }
        }
    }
}
