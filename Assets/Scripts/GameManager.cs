using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Game Manager
    // Indicate dialogue showing status
    public static bool isDialogueShowing;

    // Map Arena unlock
    bool isTheMapVisible;
    [SerializeField]public static bool isArenaTwoUnlock;
    [SerializeField]public static bool isArenaThreeUnlock;

    // Map panel
    [SerializeField] GameObject mapOne;
    [SerializeField] GameObject mapTwo;
    [SerializeField] GameObject mapThree;

    private GameObject playerGladiatorsStore;

    // Gladiator reset button
    private GameObject gladiatorReset;

    private void Start()
    {
        //if (SceneManager.GetActiveScene().name == "The Arena1"
        //    || SceneManager.GetActiveScene().name == "The Arena2"
        //    || SceneManager.GetActiveScene().name == "The Arena3")
        //{
        //    gladiatorReset = GameObject.Find("GameButtons");
        //}

        // Set to false by default
        isDialogueShowing = false;

        isArenaTwoUnlock = false;
        isArenaThreeUnlock = false;
        isTheMapVisible = false;

        playerGladiatorsStore = GameObject.FindGameObjectWithTag("PlayerGladiatorsStore");

    }

    private void Update()
    {
        // For currency test
        // L: Ludus scene
        if(Input.GetKeyDown(KeyCode.L))
        {
            if (SceneManager.GetActiveScene().buildIndex != 1)
            {
                SceneManager.LoadScene(1);
            }

        }

        // A: Arena scene
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (SceneManager.GetActiveScene().buildIndex != 2)
            {
                SceneManager.LoadScene(2);
            }

        }

        // T: Tavern scene
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (SceneManager.GetActiveScene().buildIndex != 5)
            {
                SceneManager.LoadScene(5);
            }

        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            MapOnMapOff();
        }
    }

    public void MapOnMapOff()
    {
        TitusDialogue.isMapIconBlink = false;

        if (GameObject.Find("CanvasDialogue5") != null)
        {
            GameObject.Find("CanvasDialogue5").SetActive(false);
        }

        
        if (isTheMapVisible == false)
        {
            mapOne.SetActive(true);
            isTheMapVisible = true;

            if (isArenaTwoUnlock == true)
            {
                mapTwo.SetActive(true);
            }

            if (isArenaThreeUnlock == true)
            {
                mapThree.SetActive(true);
            }

        }
        else if (isTheMapVisible == true)
        {
            mapOne.SetActive(false);
            isTheMapVisible = false;
            mapTwo.SetActive(false);
            mapThree.SetActive(false);
        }
    }

    public void OpenScene(string buttonName)
    {
        // Check if current scene is Arena
        // Reset gladiator store counter when leave arena

        if (SceneManager.GetActiveScene().name == "The Arena1"
            || SceneManager.GetActiveScene().name == "The Arena2"
            || SceneManager.GetActiveScene().name == "The Arena3")
        {
            gladiatorReset = GameObject.Find("GameButtons");

            gladiatorReset.gameObject.GetComponent<ButtonsController>().ResetGladiators(true);
        }


        switch (buttonName)
        {
            case "Arena1Button":
                if (GlobalGameManager.isDemoPlaying == true &&
                    GlobalGameManager.isDemoLudusFinished == false)
                {
                    playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterThraex++;
                }

                if (GlobalGameManager.isDemoLudusFinished == true
                    && GlobalGameManager.isArenaOneDemoBattleFinished == true)
                {
                    GlobalGameManager.isDemoPlaying = false;
                }

                SceneManager.LoadScene(2);
                MapOnMapOff();
                GlobalGameManager.isDemoLudusFinished = true;
                break;

            case "Arena2Button":

                if (GlobalGameManager.isDemoPlaying == false)
                {
                    SceneManager.LoadScene(3);
                    MapOnMapOff();
                }
                
                break;

            case "Arena3Button":

                if (GlobalGameManager.isDemoPlaying == false)
                {
                    SceneManager.LoadScene(4);
                    MapOnMapOff();
                }
                
                break;

            case "PlayerLudus Button":


                if (GlobalGameManager.isDemoPlaying == false
                    ||
                    GlobalGameManager.isDemoLudusFinished == true
                    && GlobalGameManager.isArenaOneDemoBattleFinished == true)
                {
                    SceneManager.LoadScene(0);
                    MapOnMapOff();
                    GlobalGameManager.isDemoPlaying = false;
                }
                
                break;

            case "TavernMarket Button":


                if (GlobalGameManager.isDemoPlaying == false
                    ||
                    GlobalGameManager.isDemoLudusFinished == true
                    && GlobalGameManager.isArenaOneDemoBattleFinished == true)
                {
                    SceneManager.LoadScene(5);
                    MapOnMapOff();
                    GlobalGameManager.isDemoPlaying = false;
                }
                
                break;
        }
    }

}
