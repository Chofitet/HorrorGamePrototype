using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;


public class OnTriggerGravity : MonoBehaviour
{
    public RotateAxis axis;
    public bool _OnTriggerGravity;
    public Transform AuxPlayer;
    [SerializeField] Transform Player;
    RotateRoom room;
    [SerializeField] int zSign;
    [SerializeField] GameObject OpositeCollider;
    FirstPersonControl firstPerson;
    private void Start()
    {
        room = GetComponentInParent<RotateRoom>();
        firstPerson = FindObjectOfType<FirstPersonControl>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Enter");
            firstPerson.enabled = false;
        }
    }
    private void OnTriggerStay  (Collider other)
    {
        if(other.tag == "Player")
        {
            AuxPlayer = Player;

            if(axis == RotateAxis.zAxis)
            {
                room.Rotate( RotateAxis.zAxis, zSign);
            }

            if (axis == RotateAxis.xAxis )
            {
                room.Rotate( RotateAxis.xAxis, zSign);
            }

            if (axis == RotateAxis.yAxis)
            {
                room.Rotate( RotateAxis.yAxis, zSign);
            }
            if (axis == RotateAxis.NegZAxis)
            {
                room.Rotate(RotateAxis.NegZAxis, zSign);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OpositeCollider.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }


}
