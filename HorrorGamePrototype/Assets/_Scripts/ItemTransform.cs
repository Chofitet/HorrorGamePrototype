using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTransform : MonoBehaviour
{
    public float Speed = 100f;
    // Update is called once per frame
    void Update()
    {
            float y = transform.rotation.y;
            float x = transform.rotation.x;
            x = Input.GetAxis("Mouse X") * Speed * Time.deltaTime;
            y = Input.GetAxis("Mouse Y") * Speed * Time.deltaTime;
            InspectorObject.CurrentObject.transform.Rotate(-Vector3.up * x, Space.World);
            InspectorObject.CurrentObject.transform.Rotate(-Vector3.forward * y, Space.World);
    }
}
