using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gladiator store data
/// </summary>

[CreateAssetMenu(menuName = "Gladiator Store", fileName = "New Gladiator Store")]
public class GladiatorStoreData : ScriptableObject
{
    [Header("Gladiator Store")]
    [SerializeField] public int counterSamnites;
    [SerializeField] public int counterThraex;
    [SerializeField] public int counterMyrmilo;
    [SerializeField] public int counterRetiarius;

}
