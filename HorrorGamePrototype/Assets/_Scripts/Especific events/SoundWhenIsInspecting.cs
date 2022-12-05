using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWhenIsInspecting : MonoBehaviour
{
    InspectorObject inspector;
    [SerializeField] AudioSource AS;
    SoundManager SM;
    InspectionObjectInRigthPositionTrigger triggerPosition;
    bool x;
    void Start()
    {
        inspector = FindObjectOfType<InspectorObject>();
        SM = FindObjectOfType<SoundManager>();
        triggerPosition = GetComponentInChildren<InspectionObjectInRigthPositionTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inspector.isInspecting && x == false && gameObject.layer == 6)
        {
            if(!triggerPosition.onTrigger) StartCoroutine(PlaySound());


            if (triggerPosition.onTrigger)
            {
                AS.clip = null;
                StopAllCoroutines();
            }
        }
    }

   IEnumerator PlaySound()
    {
        x = true;
        yield return new WaitForSeconds(Random.Range(2, 5));
        SM.PlaySoud(AS);
        yield return new WaitForSeconds(AS.clip.length);
        x = false;
    }
}
