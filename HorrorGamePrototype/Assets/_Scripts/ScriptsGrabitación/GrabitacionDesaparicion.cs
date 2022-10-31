using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabitacionDesaparicion : MonoBehaviour
{
    [SerializeField] GameObject DesappearObject;
    [SerializeField] GameObject AppearObject;
    [SerializeField] GameObject Triggers;
    [SerializeField] Transform TriggersSpot;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DesappearObject.SetActive(false);
            AppearObject.SetActive(true);
            Triggers.transform.position = TriggersSpot.position;
        }
    }
}
