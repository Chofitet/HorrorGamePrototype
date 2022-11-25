using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinklingLight : MonoBehaviour
{
    [SerializeField] TriggerCount triggerCount;
    [SerializeField] MultipleTrigger multipleTrigger;
    Animator anim;
    [SerializeField] GameObject appears;
    bool x;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(triggerCount.isTrigger && x == false)
        {
            Debug.Log("eeeee" + triggerCount.isTrigger);
            anim.SetBool("normal", true);
        }

        if(appears.activeSelf == true)
        {
            anim.SetBool("normal", false);
            anim.SetBool("fast", false);
            x = true;
        }
    }
}
