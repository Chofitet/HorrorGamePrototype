using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCount : MonoBehaviour
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
            if(trigger.GetComponent<MultipleTrigger>().onTrigger == false)
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
                if (trigger.GetComponent<MultipleTrigger>().onTrigger == true)
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
