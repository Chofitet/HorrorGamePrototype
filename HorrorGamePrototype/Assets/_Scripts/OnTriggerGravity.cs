using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OnTriggerGravity : MonoBehaviour
{
    public RotateAxis axis;
    public bool _OnTriggerGravity;
    public Transform AuxPlayer;
    [SerializeField] Transform Player;
    RotateRoom room;
    int zSign = 1;

    private void Start()
    {
        room = GetComponentInParent<RotateRoom>();
    }
    private void OnTriggerStay  (Collider other)
    {
        if(other.tag == "Player")
        {
            
            AuxPlayer = Player;
            _OnTriggerGravity = true;

            if(axis == RotateAxis.zAxis)
            {
                Debug.Log(zSign);
                room.Rotate( RotateAxis.zAxis);
            }

            if (axis == RotateAxis.xAxis)
            {
                room.Rotate( RotateAxis.xAxis);
            }

            if (axis == RotateAxis.yAxis)
            {
                room.Rotate( RotateAxis.yAxis);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }


}
