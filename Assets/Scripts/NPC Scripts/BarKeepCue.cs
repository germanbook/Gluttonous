using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarKeepCue : MonoBehaviour
{
    public GameObject dialogueTrigger;

    public void OnMouseDown()
    {
        dialogueTrigger.GetComponent<DialogueTrigger>().DisplayDialogue();
    }
}
