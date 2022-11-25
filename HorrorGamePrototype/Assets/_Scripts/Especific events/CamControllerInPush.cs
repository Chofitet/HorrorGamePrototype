using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamControllerInPush : MonoBehaviour
{
    [SerializeField] MultipleTrigger multipleTrigger;
    [SerializeField] float blendvelocity;
    CinemachineVirtualCamera Cam;
    CinemachineBrain cinemachineBrain;
    bool x;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<CinemachineVirtualCamera>();
        cinemachineBrain = FindObjectOfType<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (multipleTrigger.onTrigger && x == false)
        {
            Cam.Priority = 16;
            cinemachineBrain.m_DefaultBlend.m_Time = blendvelocity;
            StartCoroutine(Golpe());
            x = true;
        }
    }

    IEnumerator Golpe()
    {
        yield return new WaitForSeconds(1f);
        Cam.Priority = 1;
        Debug.Log("golpe");
        cinemachineBrain.m_DefaultBlend.m_Time = 1.5f;
    }
    

}
