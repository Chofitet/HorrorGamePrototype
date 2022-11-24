using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionObjectInRigthPositionTrigger : MonoBehaviour
{
    public bool onTrigger;

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Target")
        {
            onTrigger = true;
        }
    }
}
