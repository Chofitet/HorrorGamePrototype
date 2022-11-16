using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MultipleTrigger))]
public class SoundTrigger : MonoBehaviour
{
    MultipleTrigger trigger;
    [SerializeField] AudioSource AS;
    SoundManager SM;
    bool x;
    void Start()
    {
        trigger = GetComponent<MultipleTrigger>();
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

        if (!trigger.yes)
        {
            StartCoroutine(enumerable());
        }
    }

    IEnumerator enumerable ()
    {
        yield return new WaitForSeconds(AS.clip.length);
        x = false;
    }

}
