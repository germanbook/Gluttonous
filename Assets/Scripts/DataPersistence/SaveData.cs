using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //The current count of each hired Gladiator
    public int SamniteCount;
    public int ThreaxCount;
    public int RetiariusCount;
    public int MurmilloCount;

    //The current scene
    public string CurrentScene;

    //Tavern conversation system checks
    public bool TavernDialogueHasPlayerInteractedBefore;
    public bool TavernDialogueAdvancedQuestions;
    public bool TavernDialogueIntroQuestions;

    //Arena progression checks
    public bool Arena2MapUnlocked;
    public bool Arena3MapUnlocked;

    //Demo experience checks
    public bool LudusDemoExperienceFinished;
    public bool ArenaDemoExperienceFinished;


    public SaveData (PlayerGladiatorsStore data)
    {
        SamniteCount = data.counterSamnites;
        ThreaxCount = data.counterThraex;
        RetiariusCount = data.counterRetiarius;
        MurmilloCount = data.counterMyrmilo;

        CurrentScene = data.currentScene;

        TavernDialogueHasPlayerInteractedBefore = data.hasPlayerInteractedBefore;
        TavernDialogueAdvancedQuestions = data.advancedQuestionsAnsweredBefore;
        TavernDialogueIntroQuestions = data.introQuestionsAnsweredBefore;

        Arena2MapUnlocked = data.arenaTwoUnlock;
        Arena3MapUnlocked = data.arenaThreeUnlock;

        LudusDemoExperienceFinished = data.ludusDemoExperienceFinished;
        ArenaDemoExperienceFinished = data.arenaDemoExperienceFinished;
    }
}

