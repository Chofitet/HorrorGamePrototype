using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTrigger : MonoBehaviour
{
    Camera _camera;
    public bool onTrigger;

    [Header("Select trigger type")]
    [SerializeField] bool isOnScreen;
    [SerializeField] bool isOnScreenOnce;
    [SerializeField] bool isPassingThrough;
    [SerializeField] bool isClicked;
    [SerializeField] bool isPointing;

    [Header("Parameters")]
    [SerializeField] float DistantToClick = 3;
    [SerializeField] float DistantToSee = 3;

    bool x;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnScreen)
        {
            Vector3 screenPoint = _camera.WorldToViewportPoint(transform.position);
            onTrigger = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        }

        if (isOnScreenOnce)
        {
            Vector3 screenPoint = _camera.WorldToViewportPoint(transform.position);
            if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
            {
                onTrigger = true;
            }
        }

        if(isPassingThrough && x)
        {
            onTrigger = true;
        }

        if (isPointing)
        {
            Ray ray = new Ray(transform.position, _camera.transform.position - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, DistantToSee))
            { 
                if (hit.collider.tag == "Player")
                {
                    onTrigger = true;
                }
            }
        }

        if (isClicked && Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, _camera.transform.position - transform.position);
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            RaycastHit hit;
            Vector3 screenPoint = _camera.WorldToViewportPoint(transform.position);
            bool see = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            if (Physics.Raycast(ray, out hit, DistantToClick) && see)
            {
                if (hit.collider.tag == "Player")
                {
                    
                    onTrigger = true;
                }
            }
        }
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            x = true;
        }
    }
}
