using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    // Track of the current ink file to dispaly
    private Story currentStory;

    // Track of whether or not the dialogue is currently palying
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private void Awake()
    {
        if ( instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene.");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

    }

    private void Update()
    {
        // Return right away if dialogue isn't palying
        if (!dialogueIsPlaying)
        {
            return;
        }

        // Handle continuing to the next line in the dialogue when
        // space is pressed
        if (Input.GetKeyDown("space"))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJOSON)
    {
        // Start a new story
        currentStory = new Story(inkJOSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        // Debug.Log("Dialogue playing: " + dialogueIsPlaying);
    }

    private void ContinueStory()
    {
        
        
        if (currentStory.canContinue)
        {
            // Set text for the current dialogue line
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            //Debug.Log("Dialgoue finished!");
            Invoke("ExitDialogueMode", 0.2f);
        }
    }
}
