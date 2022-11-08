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
    Collider collider;
    bool onTrigger;
    private void Start()
    {
        _camera = Camera.main;
        room = GetComponentInParent<RotateRoom>();
        firstPerson = FindObjectOfType<FirstPersonControl>();
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (!room.rotando)
        {
            if ((!GetComponentInChildren<OnScreen>().onScreen || firstPerson.Crouching) && !onTrigger)
            {
                collider.enabled = false;
            }
            else collider.enabled = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        room.AsignScript(GetComponent<OnTriggerGravity>());
        if (other.tag == "Player")
        {
            onTrigger = true;
            firstPerson.enabled = false;
        }
    }
    private void OnTriggerStay  (Collider other)
    {
       
        if (!firstPerson.Crouching )
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
        }
    }


}
