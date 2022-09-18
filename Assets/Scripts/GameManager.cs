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
        // Z: Arena 1
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                SceneManager.LoadScene(3);
            }

        }
        // X: Arena 2
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (SceneManager.GetActiveScene().buildIndex != 4)
            {
                SceneManager.LoadScene(4);
            }

        }
        // C: Arena 3
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (SceneManager.GetActiveScene().buildIndex != 5)
            {
                SceneManager.LoadScene(5);
            }

        }
        // V: Arena 4
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (SceneManager.GetActiveScene().buildIndex != 6)
            {
                SceneManager.LoadScene(6);
            }

        }
        // B: Arena 5
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (SceneManager.GetActiveScene().buildIndex != 7)
            {
                SceneManager.LoadScene(7);
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
