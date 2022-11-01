using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedOtherObject : MonoBehaviour
{
    [SerializeField] ObjectType typeObject;
    public bool objectUsed;
    private NeedOtherObject ThisScript;
    MonoBehaviour[] scripts;
    public ObjectType GetObjectType()
    {
        return typeObject;
    }
    private void Start()
    {
        scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != ThisScript)
            {
                script.enabled = false;
            }
        }
    }

    public void ObjectUsed ()
    {
        objectUsed = true;

        foreach (MonoBehaviour script in scripts)
        {
            if (script != ThisScript)
            {
                script.enabled = true;
            }
        }

    }

}
