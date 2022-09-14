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

    // bools to check if its been opened atleast once
    bool firstTimeDialogue;

    void Awake()
    {
        playerGladiatorsStore = GameObject.Find("PlayerGladiatorsStore");
        //initialised dialogue box's into variables automatically without using seralized fields
        introductoryDialogue_0 = barkeepBranDialogue.transform.Find("0_Introductory_Dialogue").gameObject;
        introductoryDialogue_1 = barkeepBranDialogue.transform.Find("1_Introductory_Dialogue").gameObject;
        introductoryQuestions_2 = barkeepBranDialogue.transform.Find("2_Introductory_Questions").gameObject;
        advancedQuestions_3 = barkeepBranDialogue.transform.Find("3_Advanced_Questions").gameObject;
        hintsTipsQuestions_4 = barkeepBranDialogue.transform.Find("4_Hints_Tips_Questions").gameObject;

        //adds 
        dialogueBoxList.Add(introductoryDialogue_0);
        dialogueBoxList.Add(introductoryDialogue_1);
        dialogueBoxList.Add(introductoryQuestions_2);
        dialogueBoxList.Add(advancedQuestions_3);
        dialogueBoxList.Add(hintsTipsQuestions_4);

        

    }
    private void Start()
    {
        firstTimeDialogue = playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().hasPlayerInteractedBefore;

        if (firstTimeDialogue == true)
        {
            introductoryDialogue_0.SetActive(true);

            firstTimeDialogue = false;
        }
        else if (firstTimeDialogue == false)
        {
            introductoryDialogue_1.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // Option clicked, return the option's name
    public void optionClicked(Button button)
    {
        switch (button.gameObject.name)
        {
            
                
                
            case "Exit_Dialogue_Button":
                
                // Sets all dialoguebox's in status to false;
                GameManager.isDialogueShowing = false;
                barkeepBranDialogue.SetActive(false);

                break;

/*            case "Exit_Dialogue_Button":

                // Set dialogue status to false;
                GameManager.isDialogueShowing = false;


                break;

*/


        }
    }

}
