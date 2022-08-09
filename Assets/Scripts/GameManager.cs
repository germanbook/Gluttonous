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
        if(Input.GetKeyDown(KeyCode.C))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(0);
            }

            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }

        }
    }
}
