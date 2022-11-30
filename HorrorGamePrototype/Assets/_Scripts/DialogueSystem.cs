using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    TMP_Text Dialogue;
    Ray ray;
    RaycastHit hit;
    [SerializeField] float Distant = 1.15f;
    float AuxDistant;
    Inventary inventary;
    int CommentaryNumber;

    [SerializeField] GameObject flipRoom;
    [SerializeField] GameObject BaseRoom;
    [SerializeField] GameObject DoorAnimated;
    [SerializeField] GameObject DoorDraggeable;
    [SerializeField] GameObject DoorStatic;
    // Start is called before the first frame update
    void Start()
    {
        inventary = FindObjectOfType<Inventary>();
        Dialogue = GetComponentInChildren<TMP_Text>();
        AuxDistant = Distant;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0))
        {
            if (hit.collider.GetComponent<Dialogue>() != null)
            {
                if (hit.distance < Distant)
                {
                    CheckItems();
                    hit.collider.GetComponent<Dialogue>().AsignText(Dialogue, CommentaryNumber);
                    StartCoroutine(DialogueColdDown());
                    Distant = 0;
                }
            }
        }

        if(CommentaryNumber == 2)
        {
            flipRoom.SetActive(true);
            DoorAnimated.SetActive(false);
        }
        else if (CommentaryNumber == 3)
        {
            BaseRoom.SetActive(false);
            DoorStatic.SetActive(true);
        }
    }

    
    IEnumerator DialogueColdDown ()
    {
        yield return new WaitForSeconds(3);
        Dialogue.text = "";
        Distant = AuxDistant;
    }

    void CheckItems ()
    {
        if (inventary.ContainsObject(ObjectType.glassdarkstuff))
        {
            CommentaryNumber = 1;
        }
        else if (inventary.ContainsObject(ObjectType.glass))
        {
            CommentaryNumber = 2;
        }
        else if (inventary.ContainsObject(ObjectType.glasswater))
        {
            CommentaryNumber = 3;
        }


    }
}
