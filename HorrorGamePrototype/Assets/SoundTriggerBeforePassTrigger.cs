using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerBeforePassTrigger : MonoBehaviour
{
    MultipleTrigger trigger;
    [SerializeField] AudioSource AS;
    SoundManager SM;
    bool x;
    bool y;
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

        if (!trigger.yes && x == true && y == false)
        {
            y = true;
            StartCoroutine(enumerable());
        }
    }

    IEnumerator enumerable()
    {
        yield return new WaitForSeconds(AS.clip.length);
        x = false;
        y = false;
    }
}
