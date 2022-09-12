using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateAxis
{
    xAxis,
    yAxis,
    zAxis,
}
public class RotateRoom : MonoBehaviour
{
    OnTriggerGravity triggerGravity;
    float speed = 100;

    private void Start()
    {
        triggerGravity = GetComponentInChildren<OnTriggerGravity>();

    }

    private void Update()
    {
        /* if(triggerGravity._OnTriggerGravity)
         {
             Rotate();
         }
        */
        Debug.Log(transform.eulerAngles.z);
    }
    public void Rotate( RotateAxis axis, int Sign)
    {
        
        /*if (transform.rotation.z <= 0.70f && transform.rotation.z >= 0)
        {
           transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, 1), 150 * Time.deltaTime);
        }
        */
        if (axis == RotateAxis.zAxis)
        {
            
            if (Sign == 1)
            {
                if (transform.eulerAngles.z <= 90 )
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, Sign), speed * Time.deltaTime);
                }
            }
            if (Sign == -1)
            {
                if (transform.eulerAngles.z > 3)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, Sign), speed * Time.deltaTime);
                }
            }

        }
        if (axis == RotateAxis.xAxis)
        {
            if (Sign == 1)
            {
                if (transform.eulerAngles.x <= 90)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }
            }
            if (Sign == -1)
            {
                if (transform.eulerAngles.x > 3)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }
            }
        }
        if (axis == RotateAxis.yAxis)
        {
            if (transform.eulerAngles.z <= 50)
            {
                
            }
            if (transform.rotation.y <= 0.70f && transform.rotation.y >= 0)
            {
                Debug.Log("gira");
                transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, Sign, 0), 150 * Time.deltaTime);
            }
        }


    }

}
