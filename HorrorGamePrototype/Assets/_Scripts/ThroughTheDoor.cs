using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityStandardAssets.Characters.FirstPerson;

public class ThroughTheDoor : MonoBehaviour
{

    TimelinePlay timeline;
    CinemachineBrain BrainCam;
    CinemachineVirtualCamera FPCam;
    GameObject FPContoller;
    [SerializeField] CinemachineVirtualCamera Cam2;
    [SerializeField] CinemachineVirtualCamera Cam1;
    [SerializeField] GameObject NivelAnterior;
    [SerializeField] GameObject NivelSiguiente;


    FirstPersonControl firstPersonControl;
    int FPPriority;
    Camera camera;

    private void OnEnable()
    {
        camera = Camera.main;
        timeline = GetComponentInChildren<TimelinePlay>();
        BrainCam = FindObjectOfType<CinemachineBrain>();
        if (NivelAnterior == null) NivelAnterior = new GameObject("Nivel Anterior");
        if (NivelSiguiente == null) NivelSiguiente = new GameObject("Nivel Siguiente");

    }
    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.tag == "PortalDoor")
            {
                ActivePortal();
            }
        }
    }
    public void ActivePortal()
    {
        FPContoller = GameObject.Find("FPSController");
        firstPersonControl = FPContoller.GetComponent<FirstPersonControl>();
        FPCam = FPContoller.GetComponentInChildren<CinemachineVirtualCamera>();
        FPPriority = 15;
        StartCoroutine(corrutina());

        FPCam.m_Priority = 1;
    }

    IEnumerator corrutina()
    {
        Vector3 vector3 = FPContoller.transform.position;
        float duration = Convert.ToInt32(timeline.director.duration);

        yield return new WaitForSeconds(1.5f);
        NivelSiguiente.SetActive(true);
        firstPersonControl.enabled = false;
        vector3.x = Cam2.transform.position.x;
        vector3.z = Cam2.transform.position.z;
        timeline.StartTimeline();
        float auxblend = BrainCam.m_DefaultBlend.m_Time;
        BrainCam.m_DefaultBlend.m_Time = 0.01f;
        FPContoller.transform.position = vector3;
        yield return new WaitForSeconds(duration - 0.1f);


        Cam2.m_Priority = 12;
        firstPersonControl.enabled = true;
        transform.Find("Door").gameObject.tag = "Untagged";
        FPCam.m_Priority = FPPriority;

        Cam1.gameObject.SetActive(false);
        Cam2.gameObject.SetActive(false);
        NivelSiguiente.transform.Find("PortalDoor").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Debug.Log("paso de nivel");
        BrainCam.m_DefaultBlend.m_Time = 1.5f;
        timeline.gameObject.SetActive(false);
        NivelAnterior.SetActive(false);
    }
}
