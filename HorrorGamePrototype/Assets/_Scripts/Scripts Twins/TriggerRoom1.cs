using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRoom1 : MonoBehaviour
{
    [SerializeField] ChageObjectsManager COM;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") COM.SearchTrigger();

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") gameObject.SetActive(false);
    }

}
