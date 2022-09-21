using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDoor : MonoBehaviour
{
    public bool _OnTriggerDoor;
    public static bool PointingDoor { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PointingDoor = true;
            _OnTriggerDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _OnTriggerDoor = false;
            PointingDoor = false;

        }
    }
}
