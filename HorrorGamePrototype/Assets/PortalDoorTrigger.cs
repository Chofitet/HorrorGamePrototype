using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoorTrigger : MonoBehaviour
{
    [SerializeField] ThroughTheDoor TTD;
    static public bool PlayTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("triger");
            TTD.ActivePortal();
            PlayTime = true;
        }
    }
}
