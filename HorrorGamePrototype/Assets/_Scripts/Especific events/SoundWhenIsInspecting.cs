using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWhenIsInspecting : MonoBehaviour
{
    InspectorObject inspector;
    [SerializeField] AudioSource AS;
    SoundManager SM;
    bool x;
    void Start()
    {
        inspector = FindObjectOfType<InspectorObject>();
        SM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inspector.isInspecting && x == false && gameObject.layer == 6)
        {
            StartCoroutine(PlaySound());
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
