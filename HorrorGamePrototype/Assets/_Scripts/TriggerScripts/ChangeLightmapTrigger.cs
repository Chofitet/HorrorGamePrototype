using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MultipleTrigger))]
public class ChangeLightmapTrigger : MonoBehaviour
{
    ChangeLightmap changeLightmap;
    [SerializeField] string lightmapFolderName;
    bool onTrigger;
    private void Start()
    {
        changeLightmap = FindObjectOfType<ChangeLightmap>();
        
    }
    private void Update()
    {
        onTrigger = GetComponent<MultipleTrigger>().onTrigger;
        Debug.Log(onTrigger);
        if(onTrigger)
        {
            Debug.Log("Lightmap load: " + lightmapFolderName);
            changeLightmap.Load(lightmapFolderName);
        }
    }
}
