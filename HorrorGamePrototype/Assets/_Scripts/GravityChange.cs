using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public Vector3 gravityDirection = new Vector3(0, -1, 0);
    public float gravityStrength = 9.8f;
    public float gravityScale = 1.0f;
    public bool _GravityChange;

    private Rigidbody body;
    private GameObject go;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false; // Don't use default gravity, we're managing it ourselves
    }

    private void FixedUpdate()
    {
        // Optionally, you could normalize the gravity direction to make sure it always has length 1
        body.AddForce(gravityDirection * gravityStrength * gravityScale, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TriggerGravity")
        {
            _GravityChange = true;
            gravityDirection = new Vector3(0, 0, 9.8f);
        }
    }

}
