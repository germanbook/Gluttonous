using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int SamniteCount;
    public int ThreaxCount;
    public int RetiariusCount;
    public int MurmilloCount;

    public SaveData (PlayerGladiatorsStore data)
    {
        SamniteCount = data.counterSamnites;
        ThreaxCount = data.counterThraex;
        RetiariusCount = data.counterRetiarius;
        MurmilloCount = data.counterMyrmilo;
    }
}

