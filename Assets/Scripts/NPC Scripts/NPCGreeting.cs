using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGreeting : MonoBehaviour
{
    [SerializeField] GameObject greeting1;
    [SerializeField] GameObject greeting2;

    float ramdomNumber;
    float greetTimer;

    void Start()
    {
        if (GlobalGameManager.isNewGame == false)
        {

            ramdomNumber = Random.Range(1f, 10f);

            if (ramdomNumber > 5f)
            {
                greetTimer = 0f;
                greeting1.SetActive(true);
                greeting2.SetActive(false);
            }
            else
            {
                greetTimer = 0f;
                greeting2.SetActive(true);
                greeting1.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        greetTimer += Time.deltaTime;

        if (greetTimer >= 5f)
        {
            greeting1.SetActive(false);
            greeting2.SetActive(false);
        }

        if (GameManager.isDialogueShowing == true)
        {
            greeting1.SetActive(false);
            greeting2.SetActive(false);
        }
    }
}
