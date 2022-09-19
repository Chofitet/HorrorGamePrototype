using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorObject : MonoBehaviour
{
    Vector3 initial_position;
    Quaternion initial_rotation;
    [SerializeField] FirstPersonControl firstPerson;
    public static GameObject CurrentObject, manager;
    private Rigidbody rb;
    private Collider coll;
    bool isInspecting;
    [SerializeField] float Speed = 0.5f;
    Transform InspectionZone;
     Camera cam;
    RaycastHit hit;
   
    [SerializeField] LayerMask InspectionObject;
    public float maxDistant;
    private void Start()
    {
        InspectionZone = GetComponent<Transform>();
        manager = GameObject.Find("PhysicsManager");
        cam = Camera.main;
    }

    private void Update()
    {


        //Draw Ray
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        Debug.DrawRay(transform.position, mousePosition - transform.position, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray,out hit, maxDistant, InspectionObject))
            {
                CurrentObject = hit.collider.gameObject;
                rb = CurrentObject.GetComponent<Rigidbody>();
                
                if (isInspecting == false) { initial_position = hit.collider.transform.position; }
                initial_rotation = Quaternion.Euler(hit.collider.transform.localEulerAngles);
                if(rb != null) { rb.isKinematic = true;}
                firstPerson.enabled = false;
                StartCoroutine(MoveToTarget(CurrentObject, InspectionZone.position, Speed));
                isInspecting = true;
                manager.GetComponent<ItemTransform>().enabled = true;
                coll = CurrentObject.GetComponent<Collider>();
            }
            
        }
        if (isInspecting && Input.GetMouseButtonDown(1))
        {
            manager.GetComponent<ItemTransform>().enabled = false;
            CurrentObject.transform.rotation = Quaternion.Euler(initial_rotation.eulerAngles);
            StartCoroutine(MoveToTarget(CurrentObject, initial_position, Speed));
            isInspecting = false;
            firstPerson.enabled = true;
        }
    }

    IEnumerator MoveToTarget (GameObject currentObj, Vector3 target, float speed)
    {
        while (currentObj.transform.position != target)
        {
            currentObj.transform.position = Vector3.MoveTowards(currentObj.transform.position, target, Time.deltaTime * speed);
            yield return null;
        }
    }

}
