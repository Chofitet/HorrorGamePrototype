using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGiveOther : MonoBehaviour
{
    Inventary inventary;
    [SerializeField] ObjectType item;
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        inventary = FindObjectOfType<Inventary>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;
        Camera cam = Camera.main;

        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider == col)
            {

            }
        }
    }

}
