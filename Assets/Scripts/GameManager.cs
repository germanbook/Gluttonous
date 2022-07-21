using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
