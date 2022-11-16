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
            Vector3 auxPosition = FP.transform.position;
            FP.GetComponent<FirstPersonControl>().enabled = false;
            auxPosition.x = SpotToTeleport.position.x;
            auxPosition.y = SpotToTeleport.position.y;
            x = true;
            FP.transform.position = auxPosition;
            StartCoroutine(enumerator());
        }
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.2f);
        FP.GetComponent<FirstPersonControl>().enabled = true;
    }
}
