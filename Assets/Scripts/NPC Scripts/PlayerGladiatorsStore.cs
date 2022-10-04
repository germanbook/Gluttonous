using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGladiatorsStore : MonoBehaviour
{
    //the count of the Gladiators the player has access to
    [HideInInspector] public int counterSamnites;
    [HideInInspector] public int counterThraex;
    [HideInInspector] public int counterMyrmilo;
    [HideInInspector] public int counterRetiarius;
    //the current scene 
    [HideInInspector] public string currentScene;

    //progression of the game maps
    [HideInInspector] public bool arenaTwoUnlock;
    [HideInInspector] public bool arenaThreeUnlock;

    //the demo experience checks
    [HideInInspector] public bool ludusDemoExperienceFinished;
    [HideInInspector] public bool arenaDemoExperienceFinished;

    [SerializeField] GladiatorStoreData gladiatorStoreData;

    Scene scene;

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
        //Grabs the current scene and adds it to the currentScene variable
        scene = SceneManager.GetActiveScene();
        currentScene = scene.name;

        //Arena progression unlocked bool's grabbed from GameManager
        arenaTwoUnlock = GameManager.isArenaTwoUnlock;
        arenaThreeUnlock = GameManager.isArenaThreeUnlock;

        //Demo experience checks
        ludusDemoExperienceFinished = GlobalGameManager.isDemoLudusFinished;
        arenaDemoExperienceFinished = GlobalGameManager.isArenaOneDemoBattleFinished;

        //saves the game data in this class 
        SaveSystem.SaveData(this);
    }
    
    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        counterSamnites = data.MurmilloCount;
        counterThraex = data.ThreaxCount;
        counterMyrmilo = data.MurmilloCount;
        counterRetiarius = data.RetiariusCount;
        currentScene = data.CurrentScene;
        hasPlayerInteractedBefore = data.TavernDialogueHasPlayerInteractedBefore;
        introQuestionsAnsweredBefore = data.TavernDialogueIntroQuestions;
        advancedQuestionsAnsweredBefore = data.TavernDialogueAdvancedQuestions;

        SceneManager.LoadScene(currentScene);
    }
}