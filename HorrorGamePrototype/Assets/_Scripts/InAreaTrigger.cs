using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAreaTrigger : MonoBehaviour
{
    public bool _OnTriggerArea;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _OnTriggerArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _OnTriggerArea = false;

        }
    }
}
