using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarKeepCue : MonoBehaviour
{
    public GameObject dialogueTrigger;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dialogueTrigger.GetComponent<DialogueTrigger>().DisplayDialogue();
            DialogueTrigger.isDialogueShowing = true;
        }
    }
}
