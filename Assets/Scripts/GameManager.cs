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

    private void Start()
    {
        // Set to false by default
        isDialogueShowing = false;

        isArenaTwoUnlock = false;
        isArenaThreeUnlock = false;
        isTheMapVisible = false;

    }

    private void Update()
    {
        // For currency test
        // L: Ludus scene
        if(Input.GetKeyDown(KeyCode.L))
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }

        }

        // A: Arena scene
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (SceneManager.GetActiveScene().buildIndex != 1)
            {
                SceneManager.LoadScene(1);
            }

        }

        // T: Tavern scene
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (SceneManager.GetActiveScene().buildIndex != 2)
            {
                SceneManager.LoadScene(4);
            }

        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            MapOnMapOff();
        }
    }

    public void MapOnMapOff()
    {
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
        switch (buttonName)
        {
            case "Arena1Button":
                SceneManager.LoadScene(1);
                break;
            case "Arena2Button":
                SceneManager.LoadScene(2);
                break;
            case "Arena3Button":
                SceneManager.LoadScene(3);
                break;
            case "PlayerLudus Button":
                SceneManager.LoadScene(0);
                break;
            case "TavernMarket Button":
                SceneManager.LoadScene(4);
                break;
        }
    }



}
