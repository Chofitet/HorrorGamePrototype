using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministerSoundSinks : MonoBehaviour
{
    DialogueSystem DS;
    SoundManager SM;
    AudioSource Sound;
    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponentInChildren<AudioSource>();
        DS = FindObjectOfType<DialogueSystem>();
        SM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.15f) && Input.GetMouseButtonDown(0))
        { 
            Debug.Log(hit.collider.gameObject);
         if (hit.collider.gameObject == this.gameObject)
            {
                
                if (DS.CommentaryNumber == 0 || DS.CommentaryNumber == 2 || DS.CommentaryNumber == 3)
                {
                    //Sound.pitch = Random.Range(1.5f, 1.8f);
                    SM.PlaySoud(Sound);
                }
            }
        }
    }
}
