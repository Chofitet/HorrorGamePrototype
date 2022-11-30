using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWhenIsInspecting : MonoBehaviour
{
    InspectorObject inspector;
    [SerializeField] AudioSource AS;
    SoundManager SM;
    void Start()
    {
        inspector = FindObjectOfType<InspectorObject>();
        SM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inspector.isInspecting)
        {
            StartCoroutine(PlaySound());
        }
    }

   IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        SM.PlaySoud(AS);
        yield return new WaitForSeconds(AS.clip.length);
    }
}
