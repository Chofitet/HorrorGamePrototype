using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenPoint : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Image Pointing;
    public float alpha;
    // Start is called before the first frame update
    void Start()
    {
        Pointing = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject.tag == "Door" && hit.distance < 2)
            {
                Pointing.color = new Color(Pointing.color.r, Pointing.color.g, Pointing.color.b, 1f);
            }
            else if (hit.collider.gameObject.layer == 6 && hit.distance < 1)
            {
                Pointing.color = new Color(Pointing.color.r, Pointing.color.g, Pointing.color.b, 1f);
            }
            else if (hit.collider.gameObject.tag == "PortalDoor" && hit.distance < 2)
            {
                Pointing.color = new Color(Pointing.color.r, Pointing.color.g, Pointing.color.b, 1f);
            }

            else Pointing.color = new Color(Pointing.color.r, Pointing.color.g, Pointing.color.b, alpha);
            
        }

    }

}
