using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedOtherObject : MonoBehaviour
{
    [SerializeField] ObjectType typeObject;
    public bool objectUsed; 

    public ObjectType GetObjectType()
    {
        return typeObject;
    }

    public void ObjectUsed ()
    {
        objectUsed = true;
    }
}
