using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityStandardAssets.Characters.FirstPerson;

public class ThroughTheDoor : MonoBehaviour
{
    [SerializeField] TimelinePlay timeline;
    [SerializeField] CinemachineBrain BrainCam;
    [SerializeField] CinemachineVirtualCamera FPCam;
    [SerializeField] CinemachineVirtualCamera Cam2;
    [SerializeField] GameObject FPContoller;
    FirstPersonControl firstPersonControl;
    int FPPriority;
    [SerializeField] private MouseLook m_MouseLook;
    Camera camera;
    [SerializeField] Transform LookAt;
    private void Start()
    {
       // Cam2 = GetComponentInChildren<CinemachineVirtualCamera>();
        camera = Camera.main;
        firstPersonControl = FindObjectOfType<FirstPersonControl>();
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.tag == "PortalDoor")
            {
                Debug.Log(hit.collider);
                ActivePortal();
            }
        }
    }
    public void ActivePortal()
    {
        StartCoroutine(corrutina());
        FPPriority = FPCam.m_Priority;
        FPCam.m_Priority = 1;
    }

    IEnumerator corrutina()
    {
        Vector3 vector3 = FPContoller.transform.position;

        float duration = Convert.ToInt32(timeline.director.duration);
        yield return new WaitForSeconds(1.5f);
        firstPersonControl.enabled = false;
        vector3.x = Cam2.transform.position.x;
        vector3.z = Cam2.transform.position.z;
        timeline.StartTimeline();
        BrainCam.m_DefaultBlend.m_Time = 0.01f;
        FPContoller.transform.position = vector3;
        FPCam.transform.LookAt(LookAt);
        yield return new WaitForSeconds(duration - 0.1f);
        Cam2.m_Priority = 12;
        firstPersonControl.enabled = true;
        
        
        FPCam.m_Priority = FPPriority;
    }
}
