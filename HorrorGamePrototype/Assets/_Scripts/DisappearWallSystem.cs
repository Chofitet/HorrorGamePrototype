using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearWallSystem : MonoBehaviour
{
    [SerializeField] GameObject trigger1;
    [SerializeField] GameObject trigger2;
    [SerializeField] GameObject Pared;
    NoVisibleObjectDisappear noVisible;

    private void Start()
    {
        noVisible = GetComponent<NoVisibleObjectDisappear>();
    }

    // Update is called once per frame
    void Update()
    {
        if (noVisible.ParedDesaparecida == false)
        {
            if (trigger2.GetComponent<Enter_ExitTrigger>()._ExitTrigger)
            {
                Pared.gameObject.SetActive(false);
                trigger2.gameObject.SetActive(false);
                trigger1.gameObject.SetActive(true);
            }

            if (trigger1.GetComponent<Enter_ExitTrigger>()._EnterTrigger)
            {
                Pared.gameObject.SetActive(true);
                trigger1.gameObject.SetActive(false);
                trigger2.gameObject.SetActive(true);
            }
        }
    }
}
