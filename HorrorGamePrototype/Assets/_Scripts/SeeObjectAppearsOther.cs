using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeObjectAppearsOther : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Camera Cam;
    [SerializeField] GameObject ObjectToAppear;
    [SerializeField] GameObject ObjectToDisappear;

    private void Start()
    {
        Cam = Camera.main;
        
    }
    // Update is called once per frame
    void Update()
    {
        ray = Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && GetComponentInChildren<InAreaTrigger>()._OnTriggerArea)
        {
            if (hit.collider.gameObject == GetComponentInChildren<InAreaTrigger>().gameObject)
            {
                if (ObjectToAppear == null)
                {
                    ObjectToAppear = new GameObject("ObjectToAppear");
                }

                ObjectToAppear.SetActive(true);

                if (ObjectToDisappear == null)
                {
                    ObjectToDisappear = new GameObject("ObjectToDisappear");
                }

                Debug.Log("ObjectToDisappear");
                ObjectToDisappear.SetActive(false);
            }
        }
    }
}
