using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.ComponentModel;

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

    private void Start()
    {
        gladiatorStore = GameObject.FindGameObjectWithTag("PlayerGladiatorsStore");

        
    }

    public void BeginCombat()
    {
        arenaSceneManager.GetComponent<ArenaSceneManager>().isPause = false;
    }

    public void ResetCombat()
    {
        SceneManager.LoadScene(1);
    }

    public void GladiatorSelectorDialogue()
    {
        gladiatorSelectorUI.SetActive(true);

        myrmiloCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo);
        samniteCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterSamnites);
        threaxCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterThraex);
        retiariusCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius);
    }

    public void GladiatorSelectorDialogueClose()
    {
        gladiatorSelectorUI.SetActive(false);
    }

    public void GladiatorSelector(string gladiatorName)
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

    public void ResetGladiators()
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

            Destroy(gladiators[i]);
        }
        gladiatorSelectorUI.SetActive(false);
        GladiatorSelectorDialogue();


    }


}
