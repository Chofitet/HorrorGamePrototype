using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatingCeillingFan : MonoBehaviour
{
    
    MultipleTrigger multipleTrigger;
    Rigidbody RB;
    public float acelerate;
    public float maxVelocity; 
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponentInChildren<Rigidbody>();
        multipleTrigger = GetComponent<MultipleTrigger>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (multipleTrigger.onTrigger)
        {
            if (RB.angularVelocity.magnitude <= maxVelocity)
            {
                RB.isKinematic = false;
                RB.AddTorque(Vector3.up * acelerate);
            }
        }
        else
        {
            if (RB.angularVelocity.magnitude >= 0)
            {
                RB.AddTorque(-Vector3.up * acelerate);
            }
        }
        Debug.Log(RB.angularVelocity.y);
        if (RB.angularVelocity.y < 0)
        {
            RB.isKinematic = true;

        }
    }
}
