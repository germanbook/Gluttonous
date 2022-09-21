using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitusDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogue0;
    [SerializeField] GameObject dialogue1;
    [SerializeField] GameObject dialogue2;
    [SerializeField] GameObject dialogue3;
    [SerializeField] GameObject dialogue4;
    [SerializeField] GameObject dialogue5;

    public GameObject sceneManager;

    [SerializeField] GameObject titusDialogue1Button;
    [SerializeField] GameObject titusDialogue2Button;

    // Map Icon blink
    private GameObject mapIcon;
    private Color mapIconOriginalColor;
    public static bool isMapIconBlink;
    private float blinkTimer;

    private void Start()
    {
        mapIcon = sceneManager.gameObject.GetComponent<LudusSceneManager>().mapButton;

        mapIconOriginalColor = mapIcon.GetComponent<Image>().color;
        isMapIconBlink = false;
        blinkTimer = 0f;
    }

    void Update()
    {
        if (dialogue1.gameObject.activeSelf == true)
        {
            if (sceneManager.gameObject.GetComponent<LudusSceneManager>().tutorialThreax.gameObject.transform.position.x
                == sceneManager.gameObject.GetComponent<LudusSceneManager>().demoThreaxDestination.gameObject.transform.position.x
                &&
                sceneManager.gameObject.GetComponent<LudusSceneManager>().tutorialThreax.gameObject.transform.position.y
                == sceneManager.gameObject.GetComponent<LudusSceneManager>().demoThreaxDestination.gameObject.transform.position.y

                &&
                sceneManager.gameObject.GetComponent<LudusSceneManager>().tutorialSamnites.gameObject.transform.position.x
                == sceneManager.gameObject.GetComponent<LudusSceneManager>().demoSamnitesDestination.gameObject.transform.position.x
                &&
                sceneManager.gameObject.GetComponent<LudusSceneManager>().tutorialSamnites.gameObject.transform.position.y
                == sceneManager.gameObject.GetComponent<LudusSceneManager>().demoSamnitesDestination.gameObject.transform.position.y
                )
            {
                
                titusDialogue1Button.SetActive(true);
                sceneManager.gameObject.GetComponent<LudusSceneManager>().demoSamnitesPositioned = true;
                sceneManager.gameObject.GetComponent<LudusSceneManager>().demoThreaxPositioned = true;

            }
        }

        if (isMapIconBlink)
        {
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= 1)
            {
                MapIconBlink();
                blinkTimer = 0f;
            }
            
        }

    }

    public void ButtonClick(int index)
    {
        switch (index)
        {
            case 0:
                dialogue1.SetActive(true);
                dialogue0.SetActive(false);
                GladiatorsSpawn();
                break;
            case 1:
                dialogue2.SetActive(true);
                dialogue1.SetActive(false);

                // start fighting
                LudusSceneManager.demoStartFight = true;

                break;
            case 2:
                dialogue3.SetActive(true);
                dialogue2.SetActive(false);

                // back to start position
                sceneManager.GetComponent<LudusSceneManager>().DemoGladiatorsBacktoStartPosition();
                break;
            case 3:
                dialogue4.SetActive(true);
                dialogue3.SetActive(false);

                // Samnite leave
                sceneManager.GetComponent<LudusSceneManager>().samnitesLeave = true;

                break;
            case 4:
                dialogue5.SetActive(true);
                dialogue4.SetActive(false);

                // Map blink
                mapIcon.SetActive(true);
                isMapIconBlink = true;
                break;
            case 5:
                dialogue5.SetActive(false);
                break;

        }
    }

    public void GladiatorsSpawn()
    {
        sceneManager.gameObject.GetComponent<LudusSceneManager>().tutorialThreax.gameObject.SetActive(true);
        Invoke("GladiatorActive", 1.5f);
    }

    void GladiatorActive()
    {
        sceneManager.gameObject.GetComponent<LudusSceneManager>().tutorialSamnites.gameObject.SetActive(true);
    }

    void MapIconBlink()
    {
        mapIcon.GetComponent<Image>().color = Color.cyan;
        Invoke("ResetMapIconColor", 0.5f);
    }

    void ResetMapIconColor()
    {
        Debug.Log("blink");
        mapIcon.GetComponent<Image>().color = mapIconOriginalColor;
    }
}
