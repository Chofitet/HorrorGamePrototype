using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;


public class OnTriggerGravity : MonoBehaviour
{
    public RotateAxis axis;
    public Transform AuxPlayer;
    [SerializeField] Transform Player;
    RotateRoom room;
    [SerializeField] int zSign;
    [SerializeField] GameObject OpositeCollider;
    FirstPersonControl firstPerson;
    Camera _camera;
    MultipleTrigger PointToSee; 
    Collider collider;
    bool onTrigger;
    bool OnEnterOnScreen;
    private void Start()
    {
        _camera = Camera.main;
        room = GetComponentInParent<RotateRoom>();
        firstPerson = FindObjectOfType<FirstPersonControl>();
        collider = GetComponent<Collider>();
        PointToSee = GetComponentInChildren<MultipleTrigger>();
    }

    private void Update()
    {
        if (!room.rotando)
        {
            if ((!PointToSee.onTrigger || firstPerson.Crouching) && !onTrigger)
            {
                collider.enabled = false;
            }
            else collider.enabled = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (collider.bounds.Contains(Player.position))
        {
           PointToSee.gameObject.SetActive(false);
        }
        if (GetComponentInChildren<MultipleTrigger>().onTrigger) OnEnterOnScreen = true;

        room.AsignScript(GetComponent<OnTriggerGravity>());
        if (other.tag == "Player" && OnEnterOnScreen)
        {
            onTrigger = true;
            firstPerson.enabled = false;
        }
       
        
    }
    private void OnTriggerStay  (Collider other)
    {
       
        if (!firstPerson.Crouching && OnEnterOnScreen)
        {
            if (other.tag == "Player")
            {
                onTrigger = true;
                AuxPlayer = Player;

                if (axis == RotateAxis.zAxis)
                {
                    room.Rotate(RotateAxis.zAxis, zSign);
                }
                if (axis == RotateAxis.xAxis)
                {
                    room.Rotate(RotateAxis.xAxis, zSign);
                }
                if (axis == RotateAxis.xAxis2)
                {
                    room.Rotate(RotateAxis.xAxis2, zSign);
                }
                if (axis == RotateAxis.xAxis3)
                {
                    room.Rotate(RotateAxis.xAxis3, zSign);
                }
                if (axis == RotateAxis.xAxis4)
                {
                    room.Rotate(RotateAxis.xAxis4, zSign);
                }
                if (axis == RotateAxis.yAxis)
                {
                    room.Rotate(RotateAxis.yAxis, zSign);
                }
                if (axis == RotateAxis.NegZAxis)
                {
                    room.Rotate(RotateAxis.NegZAxis, zSign);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onTrigger = false;
            gameObject.SetActive(false);
            OpositeCollider.gameObject.SetActive(true);
            PointToSee.gameObject.SetActive(true);
        }
        OnEnterOnScreen = false;
    }


}
