using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    private List<ObjectType> inventory;



    private void Awake()
    {
        inventory = new List<ObjectType>();
    }

    public void AddObject(ObjectType Object)
    {
        inventory.Add(Object);
    }
    public void RemoveObject(ObjectType Object)
    {
        inventory.Remove(Object);
    }

    public bool ContainsObject(ObjectType Object)
    {
        return inventory.Contains(Object);
    }

    private void Update()
    {
        CheckInteract();
    }

    void CheckInteract ()
    {
        Ray ray;
        RaycastHit hit;
        Camera cam = Camera.main;

        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                TypeObject obj = hit.collider.GetComponent<TypeObject>();
                if (obj != null)
                {
                    AddObject(obj.GetObjectType());
                    Destroy(obj.gameObject);
                }
            }
            if (hit.collider.gameObject.layer == 7)
            {
                NeedOtherObject obj = hit.collider.GetComponent<NeedOtherObject>();
                if (obj != null)
                {
                    if (ContainsObject(obj.GetObjectType()))
                    {
                        obj.ObjectUsed();
                    }
                }
            }
        }
       
    }

}
