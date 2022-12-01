using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreiggerCountAppearsDesappear : MonoBehaviour
{
    TriggerCountOfTriggerCount triggerCount;
    [SerializeField] GameObject ObjectToAppear;
    [SerializeField] GameObject ObjectToDisappear;

    // Start is called before the first frame update
    void Start()
    {
        triggerCount = GetComponent<TriggerCountOfTriggerCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerCount.isTrigger)
        {
            if (ObjectToAppear == null)
            {
                ObjectToAppear = new GameObject("ObjectToAppear");
            }
            ObjectToAppear.SetActive(true);

            if (ObjectToDisappear == null)
            {
                ObjectToDisappear = new GameObject("ObjectToDisappear");
            }
            ObjectToDisappear.SetActive(false);
        }
    }
}
