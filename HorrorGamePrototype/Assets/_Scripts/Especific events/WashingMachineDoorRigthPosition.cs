using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineDoorRigthPosition : MonoBehaviour
{
    HingeJoint joint;
    [SerializeField] GameObject shoe;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joint.angle < -40)
        {
            shoe.SetActive(true);
        }
        else shoe.SetActive(false);

    }
}
