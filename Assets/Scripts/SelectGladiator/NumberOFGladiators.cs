using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberOFGladiators : MonoBehaviour
{

    private GameObject playerGladiatorsStore;

    [SerializeField] GameObject ChoiceUI;
    [SerializeField] Text threaxCounter;
    [SerializeField] Text samniteCounter;
    [SerializeField] Text myrmiloCounter;
    [SerializeField] Text retiariusCounter;


    private void Start()
    {
      
        // gladiator store
        playerGladiatorsStore = GameObject.FindGameObjectWithTag("PlayerGladiatorsStore");

        
    }



    // Show number of gladiators stored in the ChoiceUI
    public void numberOFGladiators(string gladiatorTag)
    {
        if (checkBalance(gladiatorTag))
        {
            switch (gladiatorTag)
            {
                case "D2_Threax":

                    ChoiceUI.SetActive(true);
                    threaxCounter.text = "Threax: " + Convert.ToString(playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterThraex);
                    break;

                case "D2_Samnites":

                    ChoiceUI.SetActive(true);
                    samniteCounter.text = "Samnites: " + Convert.ToString(playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterSamnites);
                    break;

                case "D2_Myrmilo":

                    ChoiceUI.SetActive(true);
                    myrmiloCounter.text = "Murmilo: " + Convert.ToString(playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo);
                    break;

                case "D2_Retiarius":

                    ChoiceUI.SetActive(true);
                    retiariusCounter.text = "Retiarius: " + Convert.ToString(playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius);
                    break;
            }
        }
    }

    
}
