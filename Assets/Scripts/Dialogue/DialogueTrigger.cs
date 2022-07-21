using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [Header("Dialogue")]
    [SerializeField] private GameObject dialogue;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        dialogue.SetActive(false);
    }

    private void Update()
    {
        // If player is in range
        if (playerInRange)
        {
            // Show the visual cue
            visualCue.SetActive(true);
            // Click mouse key to show dialogue
            if (Input.GetMouseButton(1))
            {
                // show dialogue here
                dialogue.SetActive(true);

                // Set dialogue status
                GameManager.isDialogueShowing = true;
            }
        }
        else
        {
            visualCue.SetActive(false);
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
}