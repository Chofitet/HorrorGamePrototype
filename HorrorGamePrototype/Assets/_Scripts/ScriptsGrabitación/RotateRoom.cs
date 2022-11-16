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
    xAxis2,
    xAxis3,
    xAxis4,
}
public class RotateRoom : MonoBehaviour
{
    OnTriggerGravity triggerGravity;
    public float speed = 90;
    FirstPersonControl firstPersonControl;
    public bool rotando;
    private void OnEnable()
    {
        firstPersonControl = FindObjectOfType<FirstPersonControl>();
        
    }

    public void AsignScript(OnTriggerGravity script)
    {
        triggerGravity = script;
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
                if (transform.rotation.x <= 0.707)
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
        if (axis == RotateAxis.xAxis2)
        {
            if (Sign == 1)
            {
                if (transform.rotation.x < 1)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }

            }
            if (Sign == -1)
            {
                if (transform.rotation.x >= 0.707)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }

            }
        }
        if (axis == RotateAxis.xAxis3)
        {
            if (Sign == 1)
            {
                if (transform.eulerAngles.x >= 0.01f)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }

            }
            if (Sign == -1)
            {
                if (transform.rotation.x >= -0.707)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }

            }
        }
        if (axis == RotateAxis.xAxis4)
        {
            if (Sign == 1)
            {
                if (transform.rotation.x <= -0.707)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }

            }
            if (Sign == -1)
            {
                if (transform.eulerAngles.x >= 170)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(Sign, 0, 0), speed * Time.deltaTime);
                }

            }
        }
        if ( axis == RotateAxis.NegZAxis)
        {
            if (Sign == 1)
            {
                if (transform.eulerAngles.z >= 183)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, Sign), speed * Time.deltaTime);
                }
            }
            else
            {
                if (transform.rotation.y >= -0.707f)
                {
                    transform.RotateAround(triggerGravity.AuxPlayer.position, new Vector3(0, 0, Sign), speed * Time.deltaTime);
                }
            }
        }


    }
  
    IEnumerator Girando ()
    {
        rotando = true;
        yield return new WaitForSeconds(0.5f);
        firstPersonControl.enabled = true;
        yield return new WaitForSeconds(0.5f);
        rotando = false;

    }
  

}
