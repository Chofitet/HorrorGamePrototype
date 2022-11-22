using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAtFPC : MonoBehaviour
{
    FirstPersonControl FPC;
    void Start()
    {
        FPC = FindObjectOfType<FirstPersonControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 auxTransform = transform.position;
        Vector3 direction = (FPC.transform.position - transform.position);
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        
        /*
        Transform auxTransform = FPC.gameObject.transform;
        auxTransform.rotation.Equals(FPC.gameObject.transform *-1);
        transform.LookAt( new Vector3 (1,-1,1) * FPC.gameObject.transform);
        */
    }
}
