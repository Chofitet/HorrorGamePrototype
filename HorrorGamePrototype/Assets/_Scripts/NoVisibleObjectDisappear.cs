using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVisibleObjectDisappear : MonoBehaviour
{
    [SerializeField] GameObject PointToView;
    [SerializeField] GameObject areaTrigger;
    [SerializeField] GameObject Pared;
    [SerializeField] Enter_ExitTrigger trigger1;
    [SerializeField] Enter_ExitTrigger trigger2;
    [SerializeField] GameObject Baño;
    [SerializeField] GameObject HabitacionDesaparece;
    Camera Cam;
    public bool ParedDesaparecida;
    private void OnEnable()
    {
        Cam = Camera.main;
    }
    private void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 screenPoint = Cam.WorldToViewportPoint(PointToView.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen && areaTrigger.GetComponent<InAreaTrigger>()._OnTriggerArea && trigger2._ExitTrigger)
        {
            Pared.gameObject.SetActive(true);
            ParedDesaparecida = true;
            Baño.SetActive(true);
            HabitacionDesaparece.SetActive(true);
        }


    }
}
