using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osvaldo : MonoBehaviour
{
    [SerializeField] bool terror = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (terror)
        {
            anim.SetBool("terror", true);
        }
        else
        {
            anim.SetBool("terror", false);
        }
    }
}
