using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityLigth : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Rigidbody RB;
    bool isAntiGravity;
    [SerializeField] Transform StopPosition;
    public float fuerza;
    Light light;
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.useGravity = false;
        light = GetComponentInChildren<Light>();
    }

    void Update()
    {
        Debug.Log(isAntiGravity);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2))
        {
            Debug.Log(hit.collider.gameObject);
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag == "AntiGravityLigth")
            {
                isAntiGravity = true;
                Debug.Log("Antigravity");
            }
        }
        if (isAntiGravity)
        {
            RB.AddForce(new Vector3(0, fuerza, 0));
            if (transform.position.y >= StopPosition.position.y)
            {
                RB.velocity = Vector3.zero;
                transform.position = StopPosition.position;
                isAntiGravity = false;
                light.gameObject.SetActive(false);
            }
        }

}
}
