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
    public bool isInspecting;
    [SerializeField] float Speed = 0.5f;
    Transform InspectionZone;
     Camera cam;
    RaycastHit hit;
   
    [SerializeField] LayerMask InspectionObject;
    public float maxDistant = 1.15f;
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
        //Debug.DrawRay(cam.transform.position, mousePosition - transform.position * maxDistant, Color.red);
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxDistant, InspectionObject))
            {
            Debug.Log(hit.collider.gameObject);
        }

        if (Physics.Raycast(ray, out hit, maxDistant)) { Debug.DrawLine(ray.origin, hit.point, Color.red);}


        if (Input.GetMouseButtonDown(0))
        {
           // Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray,out hit, maxDistant, InspectionObject))
            {
                CurrentObject = hit.collider.gameObject;
                rb = CurrentObject.GetComponent<Rigidbody>();
                
                if (isInspecting == false) 
                { 
                    initial_position = hit.collider.transform.position;
                    initial_rotation = Quaternion.Euler(hit.collider.transform.localEulerAngles);
                }
                if(rb != null) { rb.isKinematic = true;}
                firstPerson.enabled = false;
                coll = CurrentObject.GetComponent<Collider>();
                coll.enabled = false;
                StartCoroutine(MoveToTarget(CurrentObject, InspectionZone.position, Speed, coll));
                isInspecting = true;
                manager.GetComponent<ItemTransform>().enabled = true;
                coll = CurrentObject.GetComponent<Collider>();
                coll.enabled = false;
            }
            
        }
        if (isInspecting && Input.GetMouseButtonDown(1))
        {
            manager.GetComponent<ItemTransform>().enabled = false;
            CurrentObject.transform.rotation = Quaternion.Euler(initial_rotation.eulerAngles);
            StartCoroutine(MoveToTarget(CurrentObject, initial_position, Speed, coll));
            isInspecting = false;
            firstPerson.enabled = true;
        }
    }

    IEnumerator MoveToTarget (GameObject currentObj, Vector3 target, float speed, Collider coll)
    {
        while (currentObj.transform.position != target)
        {
            currentObj.transform.position = Vector3.MoveTowards(currentObj.transform.position, target, Time.deltaTime * speed);
            yield return null;
        }
        if (currentObj.transform.position == initial_position)
        {
            Debug.Log("ahora");
            coll.enabled = true; 
        }
    }

}
