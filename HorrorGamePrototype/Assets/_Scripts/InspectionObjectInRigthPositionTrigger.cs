using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionObjectInRigthPositionTrigger : MonoBehaviour
{
    public bool onTrigger;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                onTrigger = true;
            }
        }
    }
}
