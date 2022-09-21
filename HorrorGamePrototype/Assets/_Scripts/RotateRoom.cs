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
    public float speed = 90;
    float Degrees;
    FirstPersonControl firstPersonControl;
    private void Start()
    {
        firstPersonControl = FindObjectOfType<FirstPersonControl>();
        triggerGravity = GetComponentInChildren<OnTriggerGravity>();
        //Teoria de mi Hermana la matemática: unity toma para los quartenions pi = 1. Entonces 2 son 360
    }
    private void Update()
    {
        Debug.Log(transform.rotation.y);
    }

    public void Rotate( RotateAxis axis, int Sign)
    {
        StartCoroutine(Girando());
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
                if (transform.rotation.x <= 0.495f)
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
        if ( axis == RotateAxis.NegZAxis)
        {
            if (Sign == 1)
            {
                if (transform.rotation.y < 0.01f)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, Sign), speed * Time.deltaTime);
                }
            }
            else
            {
                if (transform.rotation.y > -0.495f)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, Sign), speed * Time.deltaTime);
                }
            }
        }


    }
   IEnumerator Girando ()
    {
        yield return new WaitForSeconds(0.5f);
        firstPersonControl.enabled = true;
    }
  

}
