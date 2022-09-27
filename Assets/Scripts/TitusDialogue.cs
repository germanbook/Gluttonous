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
    [SerializeField] GameObject titusDialogue3Button;

    [SerializeField] GameObject demoGladiatorThreax;
    [SerializeField] GameObject demoGladiatorSamnite;

    // Map Icon blink
    private GameObject mapIcon;
    private Color mapIconOriginalColor;
    public static bool isMapIconBlink;
    private float blinkTimer;


    // Dialogue2 button delay
    private bool isStart;
    private float buttonTimer;


    private void Start()
    {
        mapIcon = sceneManager.gameObject.GetComponent<LudusSceneManager>().mapButton;

        mapIconOriginalColor = mapIcon.GetComponent<Image>().color;
        isMapIconBlink = false;
        blinkTimer = 0f;

        isStart = false;
        buttonTimer = 0f;

    }

    void Update()
    {
        // Dialogue3 button shows only after each of gladiator is interacted.
        if (demoGladiatorThreax.gameObject.GetComponent<StatsPanel>().isPanelDisplayed
            && demoGladiatorSamnite.gameObject.GetComponent<StatsPanel>().isPanelDisplayed)
        {
            titusDialogue3Button.gameObject.SetActive(true);
        }

        // Dialogue2 button delay 6s
        if (isStart == true)
        {
            buttonTimer += Time.deltaTime;
            if (buttonTimer >= 6)
            {
                titusDialogue2Button.SetActive(true);
                isStart = false;
            }
        }

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
                isStart = true;

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

                // Close gladiators panel
                demoGladiatorThreax.gameObject.GetComponent<StatsPanel>().statsPanel.enabled = false;
                demoGladiatorSamnite.gameObject.GetComponent<StatsPanel>().statsPanel.enabled = false;

                // Samnite leave
                sceneManager.GetComponent<LudusSceneManager>().samnitesLeave = true;

                break;
            case 4:
                dialogue5.SetActive(true);
                dialogue4.SetActive(false);

                // Map blink
                mapIcon.transform.localScale = new Vector3(1, 1, 1);
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
