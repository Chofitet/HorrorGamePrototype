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
    float speed = 5;

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
    }
    public void Rotate( RotateAxis axis )
    {
        int zSign = 1;
        int xSign = 1;
        int ySign = 1;
        /*if (transform.rotation.z <= 0.70f && transform.rotation.z >= 0)
        {
           transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, 1), 150 * Time.deltaTime);
        }
        */
        if (axis == RotateAxis.zAxis)
        {
            if (transform.eulerAngles.z >= 90)
            {
                zSign = -1;
            }
            if (transform.eulerAngles.z <= 90 && transform.eulerAngles.z >= 0)
            {
                Debug.Log(zSign);
                transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, zSign), 150 * Time.deltaTime);
            }
        }
        if (axis == RotateAxis.xAxis)
        {
            if (transform.eulerAngles.x >= 90)
            {
                xSign = -1;
            }
            if (transform.eulerAngles.x <= 90 && transform.eulerAngles.x >= 0)
            {
                Debug.Log("gira");
                transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(xSign, 0, 0), 150 * Time.deltaTime);
            }
        }
        if (axis == RotateAxis.yAxis)
        {
            if (transform.eulerAngles.z <= 50)
            {
                ySign = 1;
            }
            if (transform.rotation.y <= 0.70f && transform.rotation.y >= 0)
            {
                Debug.Log("gira");
                transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, ySign, 0), 150 * Time.deltaTime);
            }
        }


    }

}
