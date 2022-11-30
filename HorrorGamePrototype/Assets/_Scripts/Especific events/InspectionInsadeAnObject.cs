using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionInsadeAnObject : MonoBehaviour
{
    // Update is called once per frame
    InspectorObject inspector;

        private void Start()
    {
        inspector = FindObjectOfType<InspectorObject>();
        
    }
    void Update()
    {
       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2))
            {

            if (hit.collider.gameObject == this.gameObject)
            {
                this.gameObject.layer = 6;
            }
            else
            {
                if (!inspector.isInspecting) this.gameObject.layer = 0;
            }

            }
        

    }
}
