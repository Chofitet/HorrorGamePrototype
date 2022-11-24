using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinklingLight : MonoBehaviour
{
    [SerializeField] TriggerCount triggerCount;
    [SerializeField] MultipleTrigger multipleTrigger;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(triggerCount.isTrigger)
        {
            Debug.Log("eeeee" + triggerCount.isTrigger);
            anim.SetBool("normal", true);
        }
        else if(multipleTrigger.onTrigger)
        {
            anim.SetBool("fast", true);
        }
    }
}
