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
    // Start is called before the first frame update
    void Start()
    {
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
        if(isUpInAwake)
        {

            if (!multipleTrigger.onTrigger)
            {
                DownSwitch.SetActive(false);
                UpSwitch.SetActive(true);
            }
            else
            {
                DownSwitch.SetActive(true);
                UpSwitch.SetActive(false);
            }

        }
        else
        {
            if (multipleTrigger.onTrigger)
            {
                DownSwitch.SetActive(false);
                UpSwitch.SetActive(true);
            }
            else
            {
                DownSwitch.SetActive(true);
                UpSwitch.SetActive(false);
            }
        }


        
    }
}
