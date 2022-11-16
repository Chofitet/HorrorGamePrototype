using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObjectType
{
    glassdarkstuff,
    glass,
    glasswater,
}

public class TypeObject : MonoBehaviour
{
    [SerializeField] ObjectType objectType;
   
    public ObjectType GetObjectType()
    {
        return objectType;
    }
    private void Update()
    {

    }
}
