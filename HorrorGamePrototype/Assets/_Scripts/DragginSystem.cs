using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragginSystem : MonoBehaviour
{
    const float k_Spring = 50.0f;
    const float k_Damper = 5.0f;
    const float k_Drag = 10.0f;
    const float k_AngularDrag = 5.0f;
    const float k_Distance = 0.2f;
    const bool k_AttachToCenterOfMass = false;
    [SerializeField] float ForceOpen = 1;
    bool isClosetoDoor;
   // OnTriggerDoor triggerDoor;
    Rigidbody RB;
    Transform Player;
    [SerializeField] Transform StopPoint;
    private SpringJoint m_SpringJoint;

    private void Start()
    {
        // triggerDoor = GetComponentInChildren<OnTriggerDoor>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        RB = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (Vector3.Distance(StopPoint.position, Player.position) < 0.7)
        {
            AddForce();
        }
        else isClosetoDoor = false;

        // Make sure the user pressed the mouse down
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitDistant;

        if (Physics.Raycast(ray, out hitDistant, 2))
            {
                var mainCamera = FindCamera();
                Debug.Log(mainCamera);

                // We need to actually hit an object
                RaycastHit hit = new RaycastHit();
                if (
                    !Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                                     mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
                                     Physics.DefaultRaycastLayers))
                {

                    return;
                }
                // We need to hit a rigidbody that is not kinematic
                if (!hit.rigidbody || hit.rigidbody.isKinematic)
                {
                    return;
                }

                if (!m_SpringJoint)
                {
                    var go = new GameObject("Rigidbody dragger");
                    Rigidbody body = go.AddComponent<Rigidbody>();
                    m_SpringJoint = go.AddComponent<SpringJoint>();
                    body.isKinematic = true;
                }

                m_SpringJoint.transform.position = hit.point;
                m_SpringJoint.anchor = Vector3.zero;

                m_SpringJoint.spring = k_Spring;
                m_SpringJoint.damper = k_Damper;
                m_SpringJoint.maxDistance = k_Distance;
                m_SpringJoint.connectedBody = hit.rigidbody;

                StartCoroutine("DragObject", hit.distance);
            } 

            
        
    }

    private void FixedUpdate()
    {
        float offsetStopPoint = Mathf.Abs(StopPoint.localRotation.z - transform.localRotation.z);
        if (!m_SpringJoint)
        {
            GameObject go;
            Rigidbody body;

            if (GameObject.Find("Rigidbody dragger"))
            {
                go = GameObject.Find("Rigidbody dragger");
                body = go.GetComponent<Rigidbody>();
                m_SpringJoint = go.GetComponent<SpringJoint>();
            }
            else
            {
                go = new GameObject("Rigidbody dragger");
                body = go.AddComponent<Rigidbody>();
                m_SpringJoint = go.AddComponent<SpringJoint>();
            }

            body.isKinematic = true;
        }
        if (offsetStopPoint < 0.02 && offsetStopPoint > 0 && !isClosetoDoor)
        {
            RB.angularVelocity = new Vector3(0, 0, 0);
            RB.velocity = new Vector3(0, 0, 0);
            pulled = false;
        }
        else pulled = true;


    }

    private IEnumerator DragObject(float distance)
    {
        var oldDrag = m_SpringJoint.connectedBody.drag;
        var oldAngularDrag = m_SpringJoint.connectedBody.angularDrag;
        m_SpringJoint.connectedBody.drag = k_Drag;
        m_SpringJoint.connectedBody.angularDrag = k_AngularDrag;
        var mainCamera = FindCamera();
        while (Input.GetMouseButton(0))
        {

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            m_SpringJoint.transform.position = ray.GetPoint(distance);
            yield return null;
        }
        if (m_SpringJoint.connectedBody)
        {
            m_SpringJoint.connectedBody.drag = oldDrag;
            m_SpringJoint.connectedBody.angularDrag = oldAngularDrag;
            m_SpringJoint.connectedBody = null;
        }
      
    }

    private Camera FindCamera()
    {
        if (GetComponent<Camera>())
        {
            return GetComponent<Camera>();
        }

        return Camera.main;
    }

    bool pulled;
    private void AddForce()
    {
       
        Vector3 dir = (Player.position - transform.position);
        float dirSing = Mathf.Sign(Vector3.Dot(transform.up,dir));
        Debug.Log(dirSing);
        isClosetoDoor = true;
        if (!pulled)
        {
            if (dirSing == -1)
            {
                RB.AddForce(StopPoint.transform.position * ForceOpen);
            }

            if (dirSing == 1)
            {
                RB.AddForce(StopPoint.transform.position * -ForceOpen);
            }
            pulled = true;
        }

    }

}
