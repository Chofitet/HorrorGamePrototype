using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceObjectInStayTrigger : MonoBehaviour
{
    [SerializeField] MultipleTrigger multipleTrigger;
    [SerializeField] Transform Array;
    Vector3 Initialposition;
    [SerializeField] float speed;
    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        
        Initialposition = transform.position;
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(multipleTrigger.onTrigger)
        {
            AS.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, Array.position, speed * Time.deltaTime);

        }
        else
        {
            AS.enabled = false;
            transform.position = Initialposition;
        }

        if (transform.position == Array.position)
        {
            AS.enabled = false;
        }

    }
}
