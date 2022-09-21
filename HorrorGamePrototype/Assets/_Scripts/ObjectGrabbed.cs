using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbed : MonoBehaviour
{
    Camera cam;
    public float distant;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(transform.position);
            if (Physics.Raycast(ray, out hit, distant))
            {
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.tag == "GrabbedObject")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
