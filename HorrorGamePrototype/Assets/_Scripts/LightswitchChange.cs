using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MultipleTrigger))]
public class LightswitchChange : MonoBehaviour
{
    [SerializeField] bool isUpInAwake;
    [SerializeField] GameObject UpSwitch;
    [SerializeField] GameObject DownSwitch;
    MultipleTrigger multipleTrigger;
    [SerializeField] AudioSource Click;
    [SerializeField] AudioSource Clock;
    SoundManager SM;
    bool auxOnTriggger;
    AudioSource AuxAudio;
    // Start is called before the first frame update
    void Start()
    {
        SM = FindObjectOfType<SoundManager>();
        multipleTrigger = GetComponent<MultipleTrigger>();
        DownSwitch.SetActive(true);
        UpSwitch.SetActive(false);
        if (isUpInAwake)
        {
            DownSwitch.SetActive(false);
            UpSwitch.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isUpInAwake)
        {
            
            if (!multipleTrigger.onTrigger)
            {
                AuxAudio = Click;
                DownSwitch.SetActive(false);
                UpSwitch.SetActive(true);
            }
            else
            {
                AuxAudio = Clock;
                DownSwitch.SetActive(true);
                UpSwitch.SetActive(false);
            }
        }
        else
        {
            if (multipleTrigger.onTrigger)
            {
                AuxAudio = Click;
                DownSwitch.SetActive(false);
                UpSwitch.SetActive(true);
            }
            else
            {
                AuxAudio = Clock;
                DownSwitch.SetActive(true);
                UpSwitch.SetActive(false);
            }
        }

        if (auxOnTriggger != multipleTrigger.onTrigger)
        {
            SM.PlaySoud(AuxAudio);
        }

        auxOnTriggger = multipleTrigger.onTrigger;

    }
}
