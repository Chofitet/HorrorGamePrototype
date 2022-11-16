using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCount : MonoBehaviour
{
    [SerializeField] GameObject[] triggers;
    public bool isTrigger;
    private bool isAlltrue()
    {
        foreach (GameObject trigger in triggers)
        {
            if(trigger.GetComponent<MultipleTrigger>().onTrigger == false)
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        isAlltrue();
        if (isAlltrue()) isTrigger = true;
    }
}
