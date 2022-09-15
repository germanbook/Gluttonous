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

    private void Start()
    {
        counterSamnites = gladiatorStoreData.counterSamnites;
        counterThraex = gladiatorStoreData.counterThraex;
        counterMyrmilo = gladiatorStoreData.counterMyrmilo;
        counterRetiarius = gladiatorStoreData.counterRetiarius;
    }

    public void SaveGladiatorStoreData()
    {
        gladiatorStoreData.counterSamnites = counterSamnites;
        gladiatorStoreData.counterThraex = counterThraex;
        gladiatorStoreData.counterMyrmilo = counterMyrmilo;
        gladiatorStoreData.counterRetiarius = counterRetiarius;
    }
}
