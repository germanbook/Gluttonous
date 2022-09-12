using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
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
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
