using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] PlayerGladiatorsStore playerGladiatorsStore;

    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
        this.gameObject.SetActive(false);
    }

    public void LoadGameButton()
    {
        
    }

    public void ExitGameButton()
    {
        playerGladiatorsStore.SaveGladiatorStoreData();
  //      UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
