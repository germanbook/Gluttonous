using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    public GameObject startMenu;
    public static bool isDemoPlaying;
    public static bool isDemoLudusFinished;
    public static bool isArenaOneDemoBattleFinished;

    // Start is called before the first frame update
    void Start()
    {
        startMenu.SetActive(true);
        isArenaOneDemoBattleFinished = false;
        isDemoLudusFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (startMenu.activeSelf == true)
            {
                startMenu.SetActive(false);
            }
            else
            {
                startMenu.SetActive(true);
            }
            
        }
    }

}
