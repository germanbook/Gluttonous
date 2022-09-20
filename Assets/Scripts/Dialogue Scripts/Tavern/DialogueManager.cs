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

    // dialogue box list filled with each respective button

    GameObject[] advancedQuestionsButtons_3;
    GameObject[] hintsTipsQuestionsButtons_4;

    //bools to check if certain dialogue boxes have been opened/questions asked
    bool lanista_2_1 = false;
    bool gladiators_2_2 = false;
    bool ludus_2_3 = false;
    bool showAdvancedQuestionButton = false;

    bool arena_3_1 = false;
    bool variants_3_2 = false;
    bool showHintsTipsQuestionButton = false;
    //bools to check if its been opened atleast once
    bool firstTimeDialogue;

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
    private void Start()
    {
        

        firstTimeDialogue = playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().hasPlayerInteractedBefore;
        //not currently working, needs fix
        if (firstTimeDialogue == true)
        {
            introductoryDialogue_0.SetActive(true);

            firstTimeDialogue = false;
        }
        else if (firstTimeDialogue == false)
        {
            introductoryDialogue_1.SetActive(true);
            
        }
        doNotDisplayAdvanceddQuestionButtons();
        //adds dialogue buttons into array

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
    }
    //Method to check if the intro questions have been fully asked by the player, if they have, display the advanced questions buttons
    void IntroQuestionsAnswered()
    {
        if (lanista_2_1 && gladiators_2_2 && ludus_2_3)
        {
            showAdvancedQuestionButton = true;
        } 
    }
    public void displayAdvancedQuestionButtons()
    {
        if (showAdvancedQuestionButton)
        {
            advancedQuestionsButtons_3 = GameObject.FindGameObjectsWithTag("3_Advanced_Questions_ButtonTag");
            foreach (GameObject item in advancedQuestionsButtons_3)
            {
                item.SetActive(true);
            }
            
        } 
    }
    public void doNotDisplayAdvanceddQuestionButtons()
    {
        if (showAdvancedQuestionButton == false)
        {
            advancedQuestionsButtons_3 = GameObject.FindGameObjectsWithTag("3_Advanced_Questions_ButtonTag");
            foreach (GameObject item in advancedQuestionsButtons_3)
            {
                item.SetActive(false);
            }
        }
    }
    // Option clicked, return the option's name
    public void optionClicked(Button button)
    {
        switch (button.gameObject.name)
        {
            case "Exit_Dialogue_Button":
                
                // Sets all dialoguebox's in status to false;
                GameManager.isDialogueShowing = false;
                CloseDialogueBox();

                break;

            case "2_Introduction_Questions_Button":
                CloseDialogueBox();

                introductoryQuestions_2.SetActive(true);
                displayAdvancedQuestionButtons();
                doNotDisplayAdvanceddQuestionButtons();
                break;

            case "2.1_Button":

                CloseDialogueBox();
                lanista_2_1 = true;
                IntroQuestionsAnswered();
                Lanista_2_1.SetActive(true);
                displayAdvancedQuestionButtons();
                doNotDisplayAdvanceddQuestionButtons();

                break;

            case "2.2_Button":

                CloseDialogueBox();
                gladiators_2_2 = true;
                IntroQuestionsAnswered();
                Gladiators_2_2.SetActive(true);
                displayAdvancedQuestionButtons();
                doNotDisplayAdvanceddQuestionButtons();

                break;
            case "2.3_Button":
                CloseDialogueBox();
                ludus_2_3 = true;
                IntroQuestionsAnswered();

                Ludus_2_3.SetActive(true);
                displayAdvancedQuestionButtons();
                doNotDisplayAdvanceddQuestionButtons();

                break;
            case "3_Advanced_Questions_Button":
                CloseDialogueBox();

                advancedQuestions_3.SetActive(true);
                break;
            case "3.1_Button":
                CloseDialogueBox();

                Arena_3_1.SetActive(true);
                break;
            case "3.2_Button":
                CloseDialogueBox();

                Variants_3_2.SetActive(true);

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


                break;
            case "2_Back_Button":
                displayAdvancedQuestionButtons();
                CloseDialogueBox();
                IntroQuestionsAnswered();
                introductoryQuestions_2.SetActive(true);
                

                break;
            case "3_Back_Button":
                CloseDialogueBox();
                IntroQuestionsAnswered();

                advancedQuestions_3.SetActive(true);
                break;
            case "4_Back_Button":
                CloseDialogueBox();

                displayAdvancedQuestionButtons();
                hintsTipsQuestions_4.SetActive(true);
                break;


        }
    }

}
