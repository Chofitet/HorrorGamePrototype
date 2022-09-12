using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateAxis
{
    xAxis,
    yAxis,
    zAxis,
    NegXAxis,
    NegYAxis,
    NegZAxis,

}
public class RotateRoom : MonoBehaviour
{
    OnTriggerGravity triggerGravity;
    float speed = 90;
    float Degrees;
    private void Start()
    {
        triggerGravity = GetComponentInChildren<OnTriggerGravity>();
        //Teoria de mi Hermana la matemática: unity toma para los quartenions pi = 1. Entonces 2 son 360
    }

    private void Update()
    {
    }
    public void Rotate( RotateAxis axis, int Sign)
    {
        if (axis == RotateAxis.zAxis)
        {
            if (Sign == 1)
            {
                if (transform.rotation.z <= 0.707)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, Sign), speed * Time.deltaTime);
                }
            }
            if (Sign == -1)
            {
                if (transform.rotation.z > 0.01f)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, Sign), speed * Time.deltaTime);
                }
            }

        }
        if (axis == RotateAxis.yAxis)
        {
            if (Sign == 1)
            {
                if (transform.rotation.x < 0.495f)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }
            }
            if (Sign == -1)
            {
                if (transform.rotation.x > 0.01f)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }
            }
        }
        if (axis == RotateAxis.xAxis)
        {
             if (Sign == 1)
            {
                
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, Sign, 0), speed * Time.deltaTime);
                
            }
            if (Sign == -1)
            {
                
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, Sign, 0), speed * Time.deltaTime);
                
            }
        }


    }

}
