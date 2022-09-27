using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // list to store each dialogue box in 
    List<GameObject> dialogueBoxList = new List<GameObject>(); 

    //main dialogue gameObject
    public GameObject barkeepBranDialogue;

    GameObject playerGladiatorsStore;
    // dialogue box's
    GameObject introductoryDialogue_0;
    GameObject introductoryDialogue_1;
    GameObject introductoryQuestions_2;
    GameObject advancedQuestions_3;
    GameObject hintsTipsQuestions_4;
    GameObject Lanista_2_1;
    GameObject Gladiators_2_2;
    GameObject Ludus_2_3;
    GameObject Arena_3_1;
    GameObject Variants_3_2;
    GameObject Samnite_4_1;
    GameObject Retiarius_4_2;
    GameObject Murmillo_4_3;

    //bools to check if certain dialogue boxes have been opened/questions asked
    bool lanista_2_1 = false;
    bool gladiators_2_2 = false;
    bool ludus_2_3 = false;
    bool showAdvancedQuestionButton = false;

    bool arena_3_1 = false;
    bool variants_3_2 = false;
    bool showHintsTipsQuestionButton = false;
    //to check if its been opened atleast once
    bool firstTimeDialogueCheck;

    void Awake()
    {
        playerGladiatorsStore = GameObject.Find("PlayerGladiatorsStore");
        //initialised dialogue box's into variables automatically without using seralized fields
        introductoryDialogue_0 = barkeepBranDialogue.transform.Find("0_Introductory_Dialogue").gameObject;
        introductoryDialogue_1 = barkeepBranDialogue.transform.Find("1_Introductory_Dialogue").gameObject;
        
        //Introductory Questions dialogue frames
        introductoryQuestions_2 = barkeepBranDialogue.transform.Find("2_Introductory_Questions").gameObject;
        Lanista_2_1 = barkeepBranDialogue.transform.Find("2.1_Lanista").gameObject;
        Gladiators_2_2 = barkeepBranDialogue.transform.Find("2.2_Gladiators").gameObject;
        Ludus_2_3 = barkeepBranDialogue.transform.Find("2.3_Ludus").gameObject;

        //Advanced Questions dialogue frames
        advancedQuestions_3 = barkeepBranDialogue.transform.Find("3_Advanced_Questions").gameObject;
        Arena_3_1 = barkeepBranDialogue.transform.Find("3.1_Arena").gameObject;
        Variants_3_2 = barkeepBranDialogue.transform.Find("3.2_Variants").gameObject;

        //Hints and tips dialogue frames
        hintsTipsQuestions_4 = barkeepBranDialogue.transform.Find("4_Hints_Tips_Questions").gameObject;
        Samnite_4_1 = barkeepBranDialogue.transform.Find("4.1_Samnite").gameObject;
        Retiarius_4_2 = barkeepBranDialogue.transform.Find("4.2_Retiarius").gameObject;
        Murmillo_4_3 = barkeepBranDialogue.transform.Find("4.3_Murmillo").gameObject;

        //adds all dialogue boxes to a list to be used for exit all function
        dialogueBoxList.Add(introductoryDialogue_0);
        dialogueBoxList.Add(introductoryDialogue_1);
        dialogueBoxList.Add(introductoryQuestions_2);
        dialogueBoxList.Add(advancedQuestions_3);
        dialogueBoxList.Add(hintsTipsQuestions_4);
        dialogueBoxList.Add(Lanista_2_1);
        dialogueBoxList.Add(Gladiators_2_2);
        dialogueBoxList.Add(Ludus_2_3);
        dialogueBoxList.Add(Arena_3_1);
        dialogueBoxList.Add(Variants_3_2);
        dialogueBoxList.Add(Samnite_4_1);
        dialogueBoxList.Add(Retiarius_4_2);
        dialogueBoxList.Add(Murmillo_4_3);
    }
    private void OnEnable()
    {
        
        showAdvancedQuestionButton = playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().introQuestionsAnsweredBefore;
        showHintsTipsQuestionButton = playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().advancedQuestionsAnsweredBefore;
        StartIntroDialogue();
    }
    void StartIntroDialogue()
    {
        firstTimeDialogueCheck = playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().hasPlayerInteractedBefore;
   
        if (firstTimeDialogueCheck == true)
        {
            introductoryDialogue_1.SetActive(true);
            displayAdvancedQuestionButtons();
            displayHintsTipsQuestionButton();
        }
        else if (firstTimeDialogueCheck == false)
        {
            introductoryDialogue_0.SetActive(true);
            
            playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().hasPlayerInteractedBefore = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //exit all dialogue box function for easy reference
    void CloseDialogueBox()
    {
        foreach (var dialogue in dialogueBoxList)

        {
            dialogue.gameObject.SetActive(false);
        }

        // Set it back to false
        GameManager.isDialogueShowing = false;
    }
    //check if the intro questions have been fully asked by the player, if they have, display the advanced questions buttons
    void IntroQuestionsAnswered()
    {
        if (lanista_2_1 && gladiators_2_2 && ludus_2_3)
        {
            playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().introQuestionsAnsweredBefore = true;
            showAdvancedQuestionButton = playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().introQuestionsAnsweredBefore;
        } 
    }
    //checks if the advanced questions have been answered, if they have display the hints questions
    void AdvancedQuestionsAnswered()
    {
        if (arena_3_1 && variants_3_2)
        {
            playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().advancedQuestionsAnsweredBefore = true;
            showHintsTipsQuestionButton = playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().advancedQuestionsAnsweredBefore;
        }
    }
    //displays the advanced questions buttons across all dialogue boxes if conditions are met.
    public void displayAdvancedQuestionButtons()
    {
        if (showAdvancedQuestionButton)
        {
            foreach (GameObject item in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                if(item.name == "3_Advanced_Questions_Button")
                {
                    item.SetActive(true);
                }
            } 
        }
        else if (showAdvancedQuestionButton == false)
        {
            foreach (GameObject item in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                if (item.name == "3_Advanced_Questions_Button")
                {
                    item.SetActive(false);

                }
            }
        }
    }
    //displays the hints & tips questions buttons across all dialogue boxes if conditions are met.
    public void displayHintsTipsQuestionButton()
    {
        if (showHintsTipsQuestionButton)
        {
            foreach (GameObject item in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                if (item.name == "4_Hints_Tips_Questions_Button")
                {
                    item.SetActive(true);

                }
            }
        }
        else if (showHintsTipsQuestionButton == false)
        {
            foreach (GameObject item in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                if (item.name == "4_Hints_Tips_Questions_Button")
                {
                    item.SetActive(false);

                }
            }
        }
    }
    //Option clicked, return the option's name
    public void optionClicked(Button button)
    {
        switch (button.gameObject.name)
        {
            case "Exit_Dialogue_Button":

                // Sets all dialoguebox's in status to false;
                CloseDialogueBox();
                barkeepBranDialogue.SetActive(false);
                GameManager.isDialogueShowing = false;
                break;

            case "2_Introduction_Questions_Button":
                CloseDialogueBox();
                AdvancedQuestionsAnswered();
                introductoryQuestions_2.SetActive(true);
                displayAdvancedQuestionButtons();
                displayHintsTipsQuestionButton();
                break;

            case "2.1_Button":

                CloseDialogueBox();
                lanista_2_1 = true;
                IntroQuestionsAnswered();
                AdvancedQuestionsAnswered();
                Lanista_2_1.SetActive(true);
                displayAdvancedQuestionButtons();
                displayHintsTipsQuestionButton();

                break;

            case "2.2_Button":

                CloseDialogueBox();
                gladiators_2_2 = true;
                IntroQuestionsAnswered();
                AdvancedQuestionsAnswered();
                Gladiators_2_2.SetActive(true);
                displayAdvancedQuestionButtons();
                displayHintsTipsQuestionButton();

                break;
            case "2.3_Button":
                CloseDialogueBox();
                ludus_2_3 = true;
                IntroQuestionsAnswered();
                AdvancedQuestionsAnswered();

                Ludus_2_3.SetActive(true);
                displayAdvancedQuestionButtons();
                displayHintsTipsQuestionButton();
                break;
            case "3_Advanced_Questions_Button":
                CloseDialogueBox();

                advancedQuestions_3.SetActive(true);
                displayHintsTipsQuestionButton();

                break;
            case "3.1_Button":
                CloseDialogueBox();
                arena_3_1 = true;
                Arena_3_1.SetActive(true);
                AdvancedQuestionsAnswered();
                displayHintsTipsQuestionButton();

                break;
            case "3.2_Button":
                CloseDialogueBox();
                variants_3_2 = true;
                Variants_3_2.SetActive(true);
                AdvancedQuestionsAnswered();
                displayHintsTipsQuestionButton();

                break;
            case "4_Hints_Tips_Questions_Button":
                CloseDialogueBox();

                hintsTipsQuestions_4.SetActive(true);
                break;
            case "4.1_Button":
                CloseDialogueBox();

                Samnite_4_1.SetActive(true);
                break;
            case "4.2_Button":
                CloseDialogueBox();

                Retiarius_4_2.SetActive(true);
                break;
            case "4.3_Button":
                CloseDialogueBox();
                Murmillo_4_3.SetActive(true);
                break;
            case "1_Back_Button":
                CloseDialogueBox();
                IntroQuestionsAnswered();
                introductoryDialogue_1.SetActive(true);
                displayAdvancedQuestionButtons();
                displayHintsTipsQuestionButton();

                break;
            case "2_Back_Button":
                CloseDialogueBox();
                IntroQuestionsAnswered();
                AdvancedQuestionsAnswered();
                introductoryQuestions_2.SetActive(true);
                displayAdvancedQuestionButtons();
                displayHintsTipsQuestionButton();

                break;
            case "3_Back_Button":
                CloseDialogueBox();
                IntroQuestionsAnswered();
                AdvancedQuestionsAnswered();
                advancedQuestions_3.SetActive(true);
                displayHintsTipsQuestionButton();

                break;
            case "4_Back_Button":
                CloseDialogueBox();

                displayAdvancedQuestionButtons();
                hintsTipsQuestions_4.SetActive(true);
                break;
        }
    }

}
