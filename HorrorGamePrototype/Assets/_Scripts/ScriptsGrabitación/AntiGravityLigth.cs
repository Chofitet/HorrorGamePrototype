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
    SoundManager sm;
    AudioSource sound;
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.useGravity = false;
        sm = FindObjectOfType<SoundManager>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag == "AntiGravityLigth")
            {
                isAntiGravity = true;
                RB.isKinematic = false;
                StartCoroutine(ApagarLuz());
            }
        }
        if (isAntiGravity)
        {
            RB.AddForce(new Vector3(0, fuerza, 0));
            if (transform.position.y <= StopPosition.position.y)
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
        sm.PlaySoud(sound);
        Light.gameObject.SetActive(false);
        Light2.gameObject.SetActive(false);
    }
}
