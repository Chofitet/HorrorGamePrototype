using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUpActivate : MonoBehaviour
{
    [SerializeField] GameObject Object;
    [SerializeField] bool isWhenAppears;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWhenAppears)
        {
            if (Object.activeSelf == true)
            {
                gameObject.tag = "Object";
                gameObject.layer = 8;
            }
        }
        else
        {
            if (Object.activeSelf == false)
            {
                gameObject.tag = "Object";
                gameObject.layer = 8;
            }
        }
    }

    }
