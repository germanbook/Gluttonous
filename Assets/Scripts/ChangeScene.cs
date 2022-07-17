using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles transitions of different scenes through UI elements and game elements.
/// </summary>

public class ChangeScene : MonoBehaviour
{
    public void ChangeMenuScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    
}
