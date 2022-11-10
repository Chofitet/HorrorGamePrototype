using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractableObject : MonoBehaviour
{
    Light light;

    private void Start()
    {
        light = GetComponentInChildren<Light>();
    }
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player" && Input.GetMouseButton(0))
            {
                Debug.Log("extraible");
            }
        }
    }

    void Extract()
    {

    }
}
