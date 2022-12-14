using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.ComponentModel;
using Pathfinding;

/// <summary>
/// Buttons for begin and reset combat
///
/// </summary>
public class ButtonsController : MonoBehaviour
{
    public GameObject arenaSceneManager;
    public GameObject gladiatorSelectorUI;
    GameObject gladiatorStore;

    // Gladiator selector
    public TextMeshProUGUI myrmiloCounter;
    public TextMeshProUGUI samniteCounter;
    public TextMeshProUGUI threaxCounter;
    public TextMeshProUGUI retiariusCounter;


    // Gladiators
    public GameObject myrmilo;
    public GameObject samnite;
    public GameObject threax;
    public GameObject retiarius;
    private GameObject tempGladiator;

    // Gladiators position movement
    public static float GladiatorMovement = 0.4f;

    // click Gladiator selector close titus dialogue
    public GameObject dialogue1;
    public GameObject dialogue2;

    // Arena Reset Button
    public GameObject combatResetButton;

    // Gladiators, start button
    public GameObject gladiatorsButton;
    public GameObject beginButton;

    // Gladiators choose limitation remainder dialogue
    public GameObject chooseLimitation;

    private void Start()
    {
        gladiatorStore = GameObject.FindGameObjectWithTag("PlayerGladiatorsStore");
    }

    private void Update()
    {
        //toggle on or off the combat reset button
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (combatResetButton.activeSelf == false)
            {
                combatResetButton.SetActive(true);
            }
            else
            {
                combatResetButton.SetActive(false);
            }
        }

        if (GameManager.isBattling == false)
        {
            gladiatorsButton.SetActive(true);
            beginButton.SetActive(true);
        }
    }

    public void BeginCombat()
    {
        arenaSceneManager.GetComponent<ArenaSceneManager>().isPause = false;
        // Arena bgm
        arenaSceneManager.GetComponent<ArenaSceneManager>().sounds[0].Stop();
        arenaSceneManager.GetComponent<ArenaSceneManager>().sounds[1].Play();

        // hidden buttons
        gladiatorsButton.SetActive(false);
        beginButton.SetActive(false);

        GameManager.isBattling = true;
    }

    public void ResetCombat()
    {
        ResetGladiators(true);
        SceneManager.LoadScene(1);
    }

    public void GladiatorSelectorDialogue()
    {
        if (SceneManager.GetActiveScene().name == "The Arena1")
        {
            // Close Titus Dialogue1
            if (dialogue1.gameObject.activeSelf == true)
            {
                dialogue1.gameObject.SetActive(false);
            }

            // Close Titus Dialogue2
            if (dialogue2.gameObject.activeSelf == true)
            {
                dialogue2.gameObject.SetActive(false);
            }
        }


        gladiatorSelectorUI.SetActive(true);

        myrmiloCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo);
        samniteCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterSamnites);
        threaxCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterThraex);
        retiariusCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius);
    }

    public void GladiatorSelectorDialogueClose()
    {
        if (SceneManager.GetActiveScene().name == "The Arena1")
        {
            // Reopen Titus Dialogue1 when it didn't closed
            if (dialogue1.gameObject.activeSelf == false
                && TitusDialogueArenaOne.isDialogue1Showed == false)
            {
                dialogue1.gameObject.SetActive(true);
            }

            if (TitusDialogueArenaOne.isDialogue1Showed == true)
            {
                // open dialogue2 when dialogue1 has showed
                if (dialogue2.gameObject.activeSelf == false
                    && TitusDialogueArenaOne.isDialogue2Showed == false)
                {

                    if (GameObject.FindGameObjectWithTag("Player") != null)
                    {
                        dialogue2.gameObject.SetActive(true);

                    }



                }
            }
        }

        

        
        gladiatorSelectorUI.SetActive(false);
    }

    public void GladiatorSelector(string gladiatorName)
    {
        // Checking gladiators' number in arena
        // Arena 1: 1
        // Arena 2: 2
        // Arena 3: 3
        GameObject[] players;
        // Find all players
        players = GameObject.FindGameObjectsWithTag("Player");

        switch (SceneManager.GetActiveScene().name)
        {
            case ("The Arena1"):

                if (players.Length < 1)
                {
                    GladiatorSpawn(gladiatorName);
                }
                else
                {
                    chooseLimitation.SetActive(true);
                }

                break;

            case ("The Arena2"):

                if (players.Length < 2)
                {
                    GladiatorSpawn(gladiatorName);
                }
                else
                {
                    chooseLimitation.SetActive(true);
                }

                break;

            case ("The Arena3"):

                if (players.Length < 3)
                {
                    GladiatorSpawn(gladiatorName);
                }
                else
                {
                    chooseLimitation.SetActive(true);
                }

                break;

        }


        
            
    }

    public void ResetGladiators(bool isResetCombat)
    {
        GameObject[] gladiators = GameObject.FindGameObjectsWithTag("Player");
        for (int i=0; i< gladiators.Length; i++)
        {
            switch (gladiators[i].gameObject.name)
            {
                case "Samnites":

                    gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterSamnites++;

                    break;
                case "Retiarius":

                    gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius++;

                    break;
                case "Murmillo":

                    gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo++;

                    break;
                case "Threax":

                    gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterThraex++;

                    break;
            }

            gladiators[i].gameObject.SetActive(false);
            gladiators[i].transform.parent.gameObject.SetActive(false);

            gladiators[i].gameObject.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = null;

            //Destroy(gladiators[i].gameObject.transform.parent.gameObject);
        }
        gladiatorSelectorUI.SetActive(false);
        if (!isResetCombat)
        {
            GladiatorSelectorDialogue();
        }
        


    }

    void GladiatorSpawn(string gladiatorName)
    {
        switch (gladiatorName)
        {
            case ("Samnites"):

                if (gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterSamnites > 0)
                {
                    int tempCounter = gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterSamnites;

                    tempGladiator = Instantiate(samnite, samnite.transform.position, Quaternion.identity);
                    tempGladiator.name = tempGladiator.name + Convert.ToString(tempCounter);
                    tempGladiator.transform.position = new Vector2(samnite.transform.position.x + GladiatorMovement, samnite.transform.position.y);
                    samnite.transform.position = new Vector2(tempGladiator.transform.position.x + GladiatorMovement, tempGladiator.transform.position.y);
                    tempGladiator.SetActive(true);
                    gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterSamnites--;

                    gladiatorSelectorUI.SetActive(false);
                    GladiatorSelectorDialogue();

                }

                break;
            case ("Murmillo"):

                if (gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo > 0)
                {
                    int tempCounter = gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo;

                    tempGladiator = Instantiate(myrmilo, myrmilo.transform.position, Quaternion.identity);
                    tempGladiator.name = tempGladiator.name + Convert.ToString(tempCounter);
                    tempGladiator.transform.position = new Vector2(myrmilo.transform.position.x + GladiatorMovement, myrmilo.transform.position.y);
                    myrmilo.transform.position = new Vector2(tempGladiator.transform.position.x + GladiatorMovement, tempGladiator.transform.position.y);
                    tempGladiator.SetActive(true);
                    gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo--;

                    gladiatorSelectorUI.SetActive(false);
                    GladiatorSelectorDialogue();
                }

                break;
            case ("Threax"):


                if (gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterThraex > 0)
                {
                    int tempCounter = gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterThraex;

                    tempGladiator = Instantiate(threax, threax.transform.position, Quaternion.identity);
                    tempGladiator.name = tempGladiator.name + Convert.ToString(tempCounter);
                    tempGladiator.transform.position = new Vector2(threax.transform.position.x + GladiatorMovement, threax.transform.position.y);
                    threax.transform.position = new Vector2(tempGladiator.transform.position.x + GladiatorMovement, tempGladiator.transform.position.y);
                    tempGladiator.SetActive(true);
                    gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterThraex--;

                    gladiatorSelectorUI.SetActive(false);
                    GladiatorSelectorDialogue();
                }

                break;
            case ("Retiarius"):

                if (gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius > 0)
                {
                    int tempCounter = gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius;
                    int positionMovement = 10;
                    positionMovement = positionMovement - tempCounter;
                    tempGladiator = Instantiate(retiarius, retiarius.transform.position, Quaternion.identity);
                    tempGladiator.name = tempGladiator.name + Convert.ToString(tempCounter);
                    tempGladiator.transform.position = new Vector2(retiarius.transform.position.x + GladiatorMovement, retiarius.transform.position.y);
                    retiarius.transform.position = new Vector2(tempGladiator.transform.position.x + GladiatorMovement, tempGladiator.transform.position.y);
                    tempGladiator.SetActive(true);
                    gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius--;

                    gladiatorSelectorUI.SetActive(false);
                    GladiatorSelectorDialogue();
                }

                break;

        }
    }

    public void ChooseLimitationDialogueClose()
    {
        chooseLimitation.SetActive(false);
    }


}
