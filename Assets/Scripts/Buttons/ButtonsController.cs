using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

/// <summary>
/// Buttons for begin and reset combat
///
/// </summary>
public class ButtonsController : MonoBehaviour
{
    public GameObject arenaSceneManager;
    public GameObject gladiatorSelectorUI;
    GameObject gladiatorStore;

    public TextMeshProUGUI myrmiloCounter;
    public TextMeshProUGUI samniteCounter;
    public TextMeshProUGUI threaxCounter;
    public TextMeshProUGUI retiariusCounter;

    public void BeginCombat()
    {
        arenaSceneManager.GetComponent<ArenaSceneManager>().isPause = false;
    }

    public void ResetCombat()
    {
        SceneManager.LoadScene(1);
    }

    public void GladiatorSelector()
    {
        gladiatorSelectorUI.SetActive(true);
        gladiatorStore = GameObject.FindGameObjectWithTag("PlayerGladiatorsStore");
        myrmiloCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo);
        samniteCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterSamnites);
        threaxCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterThraex);
        retiariusCounter.text = Convert.ToString(gladiatorStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius);
    }

    public void GladiatorSelectorClose()
    {
        gladiatorSelectorUI.SetActive(false);
    }

}
