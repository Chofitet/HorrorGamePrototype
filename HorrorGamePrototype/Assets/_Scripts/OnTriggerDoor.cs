using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDoor : MonoBehaviour
{
    static public bool _OnTriggerDoor {get; private set; }
    
    private void Update()
    {
        Debug.Log(_OnTriggerDoor);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _OnTriggerDoor = true;
            Debug.Log(other);
            Debug.Log(_OnTriggerDoor);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _OnTriggerDoor = false;
            Debug.Log(other);
            Debug.Log(_OnTriggerDoor);
               
        }
    }
}
