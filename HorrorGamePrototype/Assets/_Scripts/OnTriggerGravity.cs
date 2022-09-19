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

    private void Start()
    {
        room = GetComponentInParent<RotateRoom>();

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


        }
    }

    private void OnTriggerExit(Collider other)
    {
            OpositeCollider.gameObject.SetActive(true);
            gameObject.SetActive(false);
    }


}
