using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageObjectsManager : MonoBehaviour
{
    [SerializeField] Collider Trigger1;
    [SerializeField] Collider Trigger2;
    [SerializeField] Collider Trigger3;

    int PhaseRoom1;
    int PhaseRoom2;
    int PhaseRoom3;



    public void SearchTrigger()
    {
        if(Trigger1.gameObject.activeSelf == false)
        {
            Room1();
            Trigger1.gameObject.SetActive(true);
        }
        else if (Trigger2.gameObject.activeSelf == false)
        {
            Room2();
            Trigger2.gameObject.SetActive(true);
        }
        else if (Trigger3.gameObject.activeSelf == false)
        {
            Room3();
            Trigger3.gameObject.SetActive(true);
        }
    }

    void Room1()
    {
        if (PhaseRoom1 == 0)
        {
            Debug.Log("phase 1 room 1");
        }
        if (PhaseRoom1 == 1)
        {
            Debug.Log("phase 2 room 1");
        }
        if (PhaseRoom1 == 2)
        {
            Debug.Log("phase 3 room 1");
        }
        if (PhaseRoom1 == 3)
        {
            Debug.Log("phase 4 room 1");
        }
            PhaseRoom1++;
    }

    void Room2()
    {
        if (PhaseRoom2 == 0)
        {
            Debug.Log("phase 1 room 2");
        }
        if (PhaseRoom2 == 1)
        {
            Debug.Log("phase 2 room 2");
        }
        if (PhaseRoom2 == 2)
        {
            Debug.Log("phase 3 room 2");
        }
        if (PhaseRoom2 == 3)
        {
            Debug.Log("phase 4 room 2");
        }
        PhaseRoom2++;

    }
    void Room3()
    {
        if (PhaseRoom3 == 0)
        {
            Debug.Log("phase 1 room 3");
        }
        if (PhaseRoom3 == 1)
        {
            Debug.Log("phase 2 room 3");
        }
        if (PhaseRoom3 == 2)
        {
            Debug.Log("phase 3 room 3");
        }
        if (PhaseRoom3 == 3)
        {
            Debug.Log("phase 4 room 3");
        }
        PhaseRoom3++;

    }


}
