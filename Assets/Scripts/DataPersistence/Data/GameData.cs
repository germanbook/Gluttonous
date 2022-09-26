using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public int samniteCount;
    public int retiariusCount;
    public int threaxCount;
    public int murmilloCount;

    // the initial values that the game starts with.
    public GameData()
    {
        samniteCount = 0;
        retiariusCount = 0;
        threaxCount = 1;
        murmilloCount = 0;
    }
}
