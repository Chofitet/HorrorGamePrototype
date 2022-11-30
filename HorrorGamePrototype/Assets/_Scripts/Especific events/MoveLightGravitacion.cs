using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLightGravitacion : MonoBehaviour
{
    [SerializeField] Transform FirstSpot;
    [SerializeField] Transform SecondSpot;
    [SerializeField] MultipleTrigger trigger;
    Vector3 initialPos;
    Vector3 offset ;
     public float followSharpness;
    FirstPersonControl FPC;
    // Start is called before the first frame update
    void Start()
    {
        FPC = FindObjectOfType<FirstPersonControl>();
        offset = new Vector3(0, 0, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (trigger.onTrigger)
        {
            Vector3 targetPosition = FPC.transform.position + offset;

            // Keep our y position unchanged.
            targetPosition.y = transform.position.y;
            targetPosition.x = transform.position.x;
            // Smooth follow.
            Mathf.Clamp(targetPosition.z, FirstSpot.position.z, SecondSpot.position.z);
            transform.position += (targetPosition - transform.position) * followSharpness;

        }

        
    }
}
