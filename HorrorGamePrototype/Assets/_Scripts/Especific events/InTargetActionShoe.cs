using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTargetActionShoe : MonoBehaviour
{
    InspectionObjectInRigthPositionTrigger inspectionObject;
    SoundManager SM;
    AudioSource audioSource;
    [SerializeField] GameObject Diente;
    bool x;

    // Start is called before the first frame update
    void Start()
    {
        inspectionObject = GetComponent<InspectionObjectInRigthPositionTrigger>();
        audioSource = GetComponentInChildren<AudioSource>();
        SM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(inspectionObject.onTrigger && x == false)
        {
            SM.PlaySoud(audioSource);
            Diente.SetActive(true);
            x = true;
        }
    }
}
