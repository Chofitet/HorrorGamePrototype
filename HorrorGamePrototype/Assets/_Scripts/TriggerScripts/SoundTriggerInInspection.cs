using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InspectionObjectInRigthPositionTrigger))]
public class SoundTriggerInInspection : MonoBehaviour
{
    InspectionObjectInRigthPositionTrigger trigger;
    [SerializeField] AudioSource AS;
    SoundManager SM;
    bool x;
    void Start()
    {
        trigger = GetComponent<InspectionObjectInRigthPositionTrigger>();
        SM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.onTrigger && x == false)
        {
            SM.PlaySoud(AS);
            x = true;
        }

    }

}
