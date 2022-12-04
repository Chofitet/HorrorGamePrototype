using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFPC : MonoBehaviour
{
    [SerializeField] Transform SpotToTeleport;
    [SerializeField] GameObject FP;
    bool x;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MultipleTrigger>().onTrigger && x == false)
        {
            Debug.Log("teleport");
            FP.GetComponent<FirstPersonControl>().enabled = false;
            Vector3 auxPosition = FP.transform.position;
            auxPosition.x = SpotToTeleport.position.x;
            auxPosition.y = SpotToTeleport.position.y;
            auxPosition.z = SpotToTeleport.position.z;
            x = true;
            FP.transform.position = auxPosition;
            StartCoroutine(enumerator());
        }
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.1f);
        FP.GetComponent<FirstPersonControl>().enabled = true;
    }
}
