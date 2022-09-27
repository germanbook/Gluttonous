using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorNPCInitiator : MonoBehaviour
{
    [Header("VendorCue")]
    [SerializeField] private GameObject VendorCue;
    [Header("VendorDialogue1")]
    [SerializeField] private GameObject VendorDialogue1;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        VendorCue.SetActive(false);
        VendorDialogue1.SetActive(false);
    }

    private void Update()
    {
        // If player is in range
        if (playerInRange)
        {
            // Show the visual cue
            VendorCue.SetActive(true);
            // Click mouse key to show dialogue
            //if (Input.GetMouseButton(1) && GameManager.isDialogueShowing == false)
            //{

            //    // show dialogue here
            //    VendorDialogue1.SetActive(true);

            //    // Set dialogue status
            //    GameManager.isDialogueShowing = true;
            //}
        }
        else
        {
            VendorCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    // Click mouse left key to show dialogue
    public void DisplayDialogue()
    {
        if (VendorCue.gameObject.activeSelf == true && GameManager.isDialogueShowing == false)
        {
            // show dialogue here
            VendorDialogue1.SetActive(true);

            // Set dialogue status
            GameManager.isDialogueShowing = true;
        }
    }
}