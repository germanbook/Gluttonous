using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject dialogueInitiator;
    [SerializeField] GameObject dialogueB;
    [SerializeField] GameObject dialogueC;
    [SerializeField] GameObject dialogueD;
    [SerializeField] GameObject dialogueD01;
    [SerializeField] GameObject dialogueD02;
    [SerializeField] GameObject dialogueD03;
    [SerializeField] GameObject dialogueD04;
    [SerializeField] GameObject dialogueE;
    [SerializeField] GameObject dialogueF;


    // Start is called before the first frame update
    void Start()
    {
        dialogueB.SetActive(false);
        dialogueC.SetActive(false);
        dialogueD.SetActive(false);
        dialogueD01.SetActive(false);
        dialogueD02.SetActive(false);
        dialogueD03.SetActive(false);
        dialogueD04.SetActive(false);
        dialogueE.SetActive(false);
        dialogueF.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Option click, return the option's tag
    public void optionClicked(Button button)
    {
        switch (button.gameObject.tag)
        {
            case "D1_01":
                // What’s a Lanista
                // Dialogue B
                dialogueInitiator.gameObject.SetActive(false);
                dialogueB.SetActive(true);
                break;
            case "D1_02":
                // Whats a Ludus
                // Dialogue C
                dialogueInitiator.gameObject.SetActive(false);
                dialogueC.SetActive(true);
                break;
            case "D1_03":
                // What types of Gladiators are there response
                // Dialogue D
                dialogueInitiator.gameObject.SetActive(false);
                dialogueD.SetActive(true);
                break;

            case "D4_01":
                // Dialogue D Option 01
                // Samnites
                dialogueD.gameObject.SetActive(false);
                dialogueD01.SetActive(true);
                break;

            case "D4_02":
                // Dialogue D Option 02
                // Threax
                dialogueD.gameObject.SetActive(false);
                dialogueD02.SetActive(true);
                break;

            case "D4_03":
                // Dialogue D Option 03
                // Myrmilo
                dialogueD.gameObject.SetActive(false);
                dialogueD03.SetActive(true);
                break;

            case "D4_04":
                // Dialogue D Option 04
                // Retiarius
                dialogueD.gameObject.SetActive(false);
                dialogueD04.SetActive(true);
                break;

            case "D1_04":
                // Dialogue E
                // What are Arenas response
                dialogueE.gameObject.SetActive(true);
                dialogueInitiator.SetActive(false);
                break;
            case "D1_05":
                // Dialogue F 
                // What kinds of items are there response
                dialogueF.gameObject.SetActive(true);
                dialogueInitiator.SetActive(false);
                break;
            case "Button_Exit":

                dialogueInitiator.gameObject.SetActive(false);
                dialogueB.gameObject.SetActive(false);
                dialogueC.gameObject.SetActive(false);
                dialogueD.gameObject.SetActive(false);
                dialogueD01.gameObject.SetActive(false);
                dialogueD02.gameObject.SetActive(false);
                dialogueD03.gameObject.SetActive(false);
                dialogueD04.gameObject.SetActive(false);
                dialogueE.gameObject.SetActive(false);
                dialogueF.gameObject.SetActive(false);

                // Set dialogue status to false;
                GameManager.isDialogueShowing = false;
                break;

            case "D2_Back":
                // Back from dialogue b
                dialogueB.gameObject.SetActive(false);
                dialogueInitiator.gameObject.SetActive(true);
                break;

            case "D3_Back":
                // Back from dialogue c
                dialogueC.gameObject.SetActive(false);
                dialogueInitiator.gameObject.SetActive(true);
                break;

            case "D4_Back":
                // Back from dialogue d
                dialogueD.gameObject.SetActive(false);
                dialogueInitiator.gameObject.SetActive(true);
                break;

            case "D5_Back":
                // Back from dialogue E
                dialogueE.gameObject.SetActive(false);
                dialogueInitiator.gameObject.SetActive(true);
                break;

            case "D6_Back":
                // Back from dialogue F
                dialogueF.gameObject.SetActive(false);
                dialogueInitiator.gameObject.SetActive(true);
                break;

            case "D4_SubOption_Back":
                // Back from dialogue d sub options
                dialogueD01.gameObject.SetActive(false);
                dialogueD02.gameObject.SetActive(false);
                dialogueD03.gameObject.SetActive(false);
                dialogueD04.gameObject.SetActive(false);
                dialogueD.gameObject.SetActive(true);
                break;


        }
    }

}
