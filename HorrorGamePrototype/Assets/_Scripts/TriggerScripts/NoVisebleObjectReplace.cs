using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVisebleObjectReplace : MonoBehaviour
{
    Transform _transform;
    Camera _camera;
    bool viewed;
    InAreaTrigger inArea;
    [SerializeField] GameObject OtherObject;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _camera = FindObjectOfType<Camera>();
        inArea = GetComponentInChildren<InAreaTrigger>();
    }
    private void Update()
    {
        if (inArea._OnTriggerArea)
        {
            Vector3 screenPoint = _camera.WorldToViewportPoint(_transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (onScreen)
            {
                viewed = true;
                Debug.Log("visto");
            }
            else if (onScreen == false && viewed)
            {
                gameObject.SetActive(false);
                OtherObject.SetActive(true);
            }
        }
    }
}
