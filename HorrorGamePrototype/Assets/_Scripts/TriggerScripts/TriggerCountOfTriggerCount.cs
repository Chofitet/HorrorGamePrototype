using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCountOfTriggerCount : MonoBehaviour
{
    [SerializeField] GameObject[] triggers;
    public bool isTrigger;

    [Header("Is a number of triggers")]
    [SerializeField] bool yes;
    [SerializeField] int num;

    private bool isAlltrue()
    {
        foreach (GameObject trigger in triggers)
        {
            if (trigger.GetComponent<TriggerCount>().isTrigger == false)
            {
                return false;
            }
        }
        return true;
    }

    private bool isAnyTrue(int num)
    {
        int x = 0;
        foreach (GameObject trigger in triggers)
        {
            if (x < num)
            {
                if (trigger.GetComponent<TriggerCount>().isTrigger == true)
                {
                    x++;
                }

            }
            else return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        isAlltrue();

        if (isAlltrue() && !yes) isTrigger = true;

        isAnyTrue(num);

        if (isAnyTrue(num) && yes) isTrigger = true;
    }
}
