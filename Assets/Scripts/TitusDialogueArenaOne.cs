using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitusDialogueArenaOne : MonoBehaviour
{

    [SerializeField] GameObject dialogue1;
    [SerializeField] GameObject dialogue2;
    [SerializeField] GameObject dialogue3;
    [SerializeField] GameObject dialogue4;

    public GameObject sceneManager;

    private bool currencyDisplayMark;

    public static bool isDialogue1Showed;
    public static bool isDialogue2Showed;

    void Start()
    {
        currencyDisplayMark = false;
        isDialogue1Showed = false;
        isDialogue2Showed = false;
    }

    void Update()
    {

        if (GlobalGameManager.isArenaOneDemoBattleFinished
            && currencyDisplayMark == false)
        {
            // show currency
            sceneManager.GetComponent<ArenaSceneManager>().currency.gameObject.transform.localScale = new Vector3(1, 1, 1);
            dialogue3.SetActive(true);
            currencyDisplayMark = true;
        }


    }

    public void ButtonClick(int index)
    {
        switch (index)
        {

            case 1:
                dialogue1.SetActive(false);
                isDialogue1Showed = true;

                if (GameObject.FindGameObjectWithTag("Player") != null)
                {
                    Debug.Log("yyyyyy");
                    dialogue2.SetActive(true);

                }

                break;
            case 2:
                dialogue2.SetActive(false);
                isDialogue2Showed = true;

                break;
            case 3:
                dialogue4.SetActive(true);
                dialogue3.SetActive(false);


                break;
            case 4:
                dialogue4.SetActive(false);

                break;

        }
    }
}
