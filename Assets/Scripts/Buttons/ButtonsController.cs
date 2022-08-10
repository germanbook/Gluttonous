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
    public GameObject arenaSceneManager;

    public void BeginCombat()
    {
        arenaSceneManager.GetComponent<ArenaSceneManager>().isPause = false;
    }

    public void ResetCombat()
    {
        SceneManager.LoadScene(1);
    }

}
