using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    public GameObject startMenu;

    // Start is called before the first frame update
    void Start()
    {
        startMenu.SetActive(true);
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
