using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaSceneManager : MonoBehaviour
{
    public bool isPause;

    // Currency
    public GameObject currency;

    // Demo objects
    public GameObject titus;
    public GameObject titusDialogue;
    public GameObject demoSamnite;

    // sounds
    // 0: entrance
    // 1: combat
    public AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        sounds[0].Play();

        currency = GameObject.Find("Currency");

        // Demo playing
        if (GlobalGameManager.isDemoPlaying
            && GlobalGameManager.isDemoLudusFinished)
        {
            // Hide currency icon
            currency.gameObject.transform.localScale = new Vector3(0, 0, 0);

            // clear all enemies for demo playing
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i=0; i<enemies.Length; i++)
            {
                enemies[i].gameObject.SetActive(false);
            }

            // show demo objects
            demoSamnite.gameObject.SetActive(true);
            titus.gameObject.SetActive(true);
            titusDialogue.gameObject.SetActive(true);
        }

        isPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
