using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOFGladiators : MonoBehaviour
{
    public int counterSamnites;
    public int counterThraex;
    public int counterMyrmilo;
    public int counterRetiarius;

    private GameObject playerGladiatorsStore;

    // Show number of gladiators stored in the ChoiceUI
    public void numberOFGladiators(string gladiatortag)
    {
        if (checkBalance(gladiatortag))
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
