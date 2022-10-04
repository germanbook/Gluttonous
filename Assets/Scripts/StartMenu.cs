using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    

    [SerializeField] PlayerGladiatorsStore playerGladiatorsStore;

    public GameObject saveButton;
    public GameObject mapButton;
    public GameObject currency;


    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
        this.gameObject.SetActive(false);
        GlobalGameManager.isDemoPlaying = true;
    }
    public void SaveGameButton()
    {
        playerGladiatorsStore.SaveData();
    }
    public void LoadGameButton()
    {
        this.gameObject.SetActive(false);
        playerGladiatorsStore.LoadData();
    }

    public void ExitGameButton()
    {
        //playerGladiatorsStore.SaveGladiatorStoreData();
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            saveButton.SetActive(false);
            mapButton.SetActive(false);
            currency.SetActive(false);
        }
        else
        {
            saveButton.SetActive(true);
            mapButton.SetActive(true);
            currency.SetActive(true);
        }
    }
}
