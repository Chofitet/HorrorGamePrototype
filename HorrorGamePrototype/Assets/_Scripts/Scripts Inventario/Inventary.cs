using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventary : MonoBehaviour
{
    private List<ObjectType> inventary;
    [SerializeField] GameObject IMGinventory;
    [SerializeField] Image IMGinventaryObject;
    [SerializeField] Transform OutsideScreen;
    bool inInventary;
    [SerializeField] Transform InScreen;
    [SerializeField] float HudSpeed;
    [Header("Image Items")] 
    
    [SerializeField] Sprite IMGNull;
    [SerializeField] Sprite IMGglass;
    [SerializeField] Sprite IMGglassdarkstuff;
    [SerializeField] Sprite IMGglasswater;

   
    private void Start()
    {
            enabled = true;
            inventary = new List<ObjectType>();
    }


    public void AddObject(ObjectType Object)
    {
        inventary.Add(Object);
        StartCoroutine(HUDColdDown());
        RefreshHud();
    }
    public void RemoveObject(ObjectType Object)
    {
        inventary.Remove(Object);
        
    }

    public bool ContainsObject(ObjectType Object)
    {
        return inventary.Contains(Object);
    }

    private void Update()
    {
        Transform auxposition; 
        auxposition = OutsideScreen;
        CheckInteract();

        if (Input.GetKey(KeyCode.Tab) )
        {
            StartCoroutine(HUDColdDown());
            RefreshHud();
        }

        if (!inInventary)
        {
            auxposition = OutsideScreen;

        } else auxposition = InScreen;

        IMGinventory.transform.position = Vector3.Lerp(IMGinventory.transform.position, auxposition.position, HudSpeed * Time.deltaTime);
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
                    RefreshHud();
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
                        RemoveObject(obj.GetObjectType());
                        RefreshHud();

                        if (obj.NeedAndGivesObject)
                        {
                            TypeObject ob = hit.collider.GetComponent<TypeObject>();
                            if (ob != null)
                            {
                                AddObject(ob.GetObjectType());
                                RefreshHud();
                            }
                        }
                    }
                }
            }
        }

    }
    void RefreshHud()
    {
        if (inventary.Contains(ObjectType.glass))
        {
            IMGinventaryObject.sprite = IMGglass;
        }
        else if (inventary.Contains(ObjectType.glassdarkstuff))
        {
            IMGinventaryObject.sprite = IMGglassdarkstuff;
        }
        else if (inventary.Contains(ObjectType.glasswater))
        {
            IMGinventaryObject.sprite = IMGglasswater;
        }
        else IMGinventaryObject.sprite = IMGNull;
    }

    IEnumerator HUDColdDown()
    {
        inInventary = true;
        yield return new WaitForSeconds(3f);
        inInventary = false;
    }

}
