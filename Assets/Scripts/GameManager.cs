using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Game Manager
    // Indicate dialogue showing status
    public static bool isDialogueShowing;

    private void Start()
    {
        // Set to false by default
        isDialogueShowing = false;

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
                SceneManager.LoadScene(2);
            }

        }
    }
}
