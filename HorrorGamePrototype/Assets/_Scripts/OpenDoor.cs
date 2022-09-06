using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        if (anim.GetBool("Open") == false)
        {
            anim.SetBool("Open", true);
            anim.SetBool("Close", false);
        }
        else
        {
            anim.SetBool("Open", false);
            anim.SetBool("Close", true);
        }
            
    }
}
