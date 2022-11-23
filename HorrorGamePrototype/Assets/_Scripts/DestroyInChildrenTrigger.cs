using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInChildrenTrigger : MonoBehaviour
{
    AudioSource Children;
    MultipleTrigger multipleTrigger;
    // Start is called before the first frame update
    void Start()
    {
        Children = GetComponentInChildren<AudioSource>();
        multipleTrigger = GetComponent<MultipleTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (multipleTrigger.onTrigger)
        {
            Destroy(Children.gameObject);
        }
    }
}
