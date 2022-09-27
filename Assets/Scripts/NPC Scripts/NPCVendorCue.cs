using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVendorCue : MonoBehaviour
{
    public GameObject trigger;

    public void OnMouseDown()
    {
        trigger.GetComponent<VendorNPCInitiator>().DisplayDialogue();
    }
}
