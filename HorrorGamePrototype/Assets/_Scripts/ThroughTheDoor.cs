using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThroughTheDoor : MonoBehaviour
{
    [SerializeField] TimelinePlay timeline;
    [SerializeField] CinemachineBrain BrainCam;
    [SerializeField] CinemachineVirtualCamera FPCam;
    int FPPriority;
   

    private void Update()
    {
        /*
        if (!BrainCam.IsBlending && FPCam.m_Priority == 1)
        {
            FPCam.m_Priority = FPPriority;
        }
        */
    }
    public void ActivePortal()
    {
        StartCoroutine(corrutina());
        FPPriority = FPCam.m_Priority;
        FPCam.m_Priority = 1;
        Debug.Log(FPCam.m_Priority);
    }

    IEnumerator corrutina()
    {
        yield return new WaitForSeconds(1.5f);
        timeline.StartTimeline();
    }
}
