using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaladiatorHire : MonoBehaviour
{

    private int currency;

    private GameObject playerGladiatorsStore;

    [SerializeField] int threaxPrice;
    [SerializeField] int samnitesPrice;
    [SerializeField] int myrmiloPrice;
    [SerializeField] int retiariusPrice;

    [SerializeField] GameObject hireSuccessDialogue;
    [SerializeField] GameObject hireFailDialogue;
    [SerializeField] GameObject hireLimitation;
    [SerializeField] Text gladiatorCounter;

    private void Start()
    {
        // currency
        currency = GameObject.FindGameObjectWithTag("CurrencyValue").GetComponent<Currency>().currencyValue;

        // gladiator store
        playerGladiatorsStore = GameObject.FindGameObjectWithTag("PlayerGladiatorsStore");

        threaxPrice = 50;
        samnitesPrice = 100;
        myrmiloPrice = 100;
        retiariusPrice = 150;

    }

    public void gladiatorHire(string gladiatorTag)
    {
        if (checkBalance(gladiatorTag))
        {
            switch (gladiatorTag)
            {
                case "D2_Threax":
                    
                    hireSuccessDialogue.SetActive(true);
                    gladiatorCounter.text ="Threax: " + Convert.ToString(playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterThraex);
                    break;

                case "D2_Samnites":
                    
                    hireSuccessDialogue.SetActive(true);
                    gladiatorCounter.text ="Samnites: " + Convert.ToString(playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterSamnites);
                    break;

                case "D2_Myrmilo":
                    
                    hireSuccessDialogue.SetActive(true);
                    gladiatorCounter.text ="Murmilo: " + Convert.ToString(playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo);
                    break;

                case "D2_Retiarius":
                    
                    hireSuccessDialogue.SetActive(true);
                    gladiatorCounter.text ="Retiarius: " + Convert.ToString(playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius);
                    break;
            }
        }
    }

    // Check if player have enough balance to hiring a gladiator
    bool checkBalance(string gladiatorTag)
    {
        Debug.Log("Currency:" + currency);

        switch (gladiatorTag)
        {
            case "D2_Threax":

                if (currency >= threaxPrice)
                {
                    if (playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterThraex < 2)
                    {
                        currency -= threaxPrice;
                        GameObject.FindGameObjectWithTag("CurrencyValue").GetComponent<Currency>().currencyValue = currency;
                        playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterThraex += 1;
                        return true;
                    }
                    else
                    {
                        hireLimitation.SetActive(true);
                        return false;
                    }
                    
                }
                else
                {
                    hireFailDialogue.SetActive(true);
                    return false;
                }


            case "D2_Samnites":

                if (currency >= samnitesPrice)
                {
                    if (playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterSamnites < 2)
                    {
                        currency -= samnitesPrice;
                        GameObject.FindGameObjectWithTag("CurrencyValue").GetComponent<Currency>().currencyValue = currency;
                        playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterSamnites += 1;
                        return true;
                    }
                    else
                    {
                        hireLimitation.SetActive(true);
                        return false;
                    }

                    
                }
                else
                {
                    hireFailDialogue.SetActive(true);
                    return false;
                }


            case "D2_Myrmilo":

                if (currency >= myrmiloPrice)
                {

                    if (playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo < 2)
                    {
                        currency -= myrmiloPrice;
                        GameObject.FindGameObjectWithTag("CurrencyValue").GetComponent<Currency>().currencyValue = currency;
                        playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo += 1;
                        return true;
                    }
                    else
                    {
                        hireLimitation.SetActive(true);
                        return false;
                    }
                    
                }
                else
                {
                    hireFailDialogue.SetActive(true);
                    return false;
                }



            case "D2_Retiarius":

                if (currency >= retiariusPrice)
                {
                    if (playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius < 2)
                    {
                        currency -= retiariusPrice;
                        GameObject.FindGameObjectWithTag("CurrencyValue").GetComponent<Currency>().currencyValue = currency;
                        playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius += 1;
                        return true;
                    }
                    else
                    {
                        hireLimitation.SetActive(true);
                        return false;
                    }

                    
                }
                else
                {
                    hireFailDialogue.SetActive(true);
                    return false;
                }
        }
        return false;
    }

    public void buttonClick()
    {
        hireSuccessDialogue.SetActive(false);
        hireFailDialogue.SetActive(false);
        GameObject.FindGameObjectWithTag("VendorDialogue").GetComponent<VendorDialogue>().VendorDialogue2.SetActive(true);
    }
}
