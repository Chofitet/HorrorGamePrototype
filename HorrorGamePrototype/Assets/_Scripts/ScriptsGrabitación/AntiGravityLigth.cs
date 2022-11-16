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
    [SerializeField] Light Light;
    [SerializeField] Light Light2;
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.useGravity = false;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag == "AntiGravityLigth")
            {
                isAntiGravity = true;
                StartCoroutine(ApagarLuz());
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
               
            }
        }


}
    IEnumerator ApagarLuz()
    {
        yield return new WaitForSeconds(1f);
        Light.gameObject.SetActive(false);
        Light2.gameObject.SetActive(false);
    }
}
