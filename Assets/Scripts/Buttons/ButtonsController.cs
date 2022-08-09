using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Buttons for begin and reset combat
///
/// </summary>
public class ButtonsController : MonoBehaviour
{
    public void BeginCombat()
    {
        Time.timeScale = 1;
    }

    public void ResetCombat()
    {
        SceneManager.LoadScene(1);
    }

}
