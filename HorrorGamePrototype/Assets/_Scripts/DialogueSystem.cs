using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    TMP_Text Dialogue;
    Ray ray;
    RaycastHit hit;
    public float Distant = 3;
    // Start is called before the first frame update
    void Start()
    {
        Dialogue = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<TMP_Text>() != null)
            {
                if (hit.distance < Distant)
                {
                    Dialogue.text = hit.collider.GetComponent<TMP_Text>().text;
                    StartCoroutine(DialogueColdDown());
                    Distant = 0;
                }
            }
        }

        

    }

    IEnumerator DialogueColdDown ()
    {
        yield return new WaitForSeconds(3);
        Dialogue.text = "";
        Distant = 3;
    }
}
