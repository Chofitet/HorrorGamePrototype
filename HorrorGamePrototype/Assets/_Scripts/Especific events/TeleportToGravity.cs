using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToGravity : MonoBehaviour
{
    MultipleTrigger multiple;
    // Start is called before the first frame update
    void Start()
    {
        multiple = GetComponent<MultipleTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(multiple.onTrigger)
        {
            StartCoroutine(enumerator());
        }

    }

    IEnumerator enumerator ()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DevelopScene");
    }
}
