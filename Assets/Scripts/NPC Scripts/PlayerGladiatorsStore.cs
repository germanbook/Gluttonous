using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGladiatorsStore : MonoBehaviour
{
    [HideInInspector] public int counterSamnites;
    [HideInInspector] public int counterThraex;
    [HideInInspector] public int counterMyrmilo;
    [HideInInspector] public int counterRetiarius;

    [SerializeField] GladiatorStoreData gladiatorStoreData;

    public bool hasPlayerInteractedBefore;
    public bool introQuestionsAnsweredBefore;
    public bool advancedQuestionsAnsweredBefore;

    private void Start()
    {
        counterSamnites = gladiatorStoreData.counterSamnites;
        counterThraex = gladiatorStoreData.counterThraex;
        counterMyrmilo = gladiatorStoreData.counterMyrmilo;
        counterRetiarius = gladiatorStoreData.counterRetiarius;

        hasPlayerInteractedBefore = false;
        introQuestionsAnsweredBefore = false;
        advancedQuestionsAnsweredBefore = false;
    }

    public void SaveGladiatorStoreData()
    {
        gladiatorStoreData.counterSamnites = counterSamnites;
        gladiatorStoreData.counterThraex = counterThraex;
        gladiatorStoreData.counterMyrmilo = counterMyrmilo;
        gladiatorStoreData.counterRetiarius = counterRetiarius;
    }
    //Utilises the SaveSystem class to save data
    //This function is used by the SaveButton
    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }
    //
    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        counterSamnites = data.MurmilloCount;
        counterThraex = data.ThreaxCount;
        counterMyrmilo = data.MurmilloCount;
        counterRetiarius = data.RetiariusCount;
    }
}