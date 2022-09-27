using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudusSceneManager : MonoBehaviour
{

    [SerializeField] GameObject galadiatorSamnites;
    [SerializeField] GameObject galadiatorThraex;
    [SerializeField] GameObject galadiatorMyrmilo;
    [SerializeField] GameObject galadiatorRetiarius;

    private GameObject playerGladiatorsStore;

    private GameObject tempGladiator;

    // Titus movement
    public Transform gladiatorDestination;
    public Transform demoThreaxDestination;
    public Transform demoSamnitesDestination;

    public Transform demoThreaxAttackDestination;
    public Transform demoSamnitesAttackDestination;
    public Transform samnitesLeaveDestination;

    public bool demoThreaxPositioned;
    public bool demoSamnitesPositioned;
    public static bool demoStartFight;
    public bool samnitesLeave;

    [SerializeField] GameObject titus;
    [SerializeField] GameObject dialogueCue;
    [SerializeField] GameObject dialogue;

    public GameObject tutorialThreax;
    public GameObject tutorialSamnites;


    // MapButton
    public GameObject mapButton;

    // Start is called before the first frame update
    void Start()
    {
        mapButton = GameObject.Find("MapButton");
        if (GlobalGameManager.isDemoPlaying == true)
        {
            
            mapButton.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            titus.SetActive(false);
            // gladiator store
            playerGladiatorsStore = GameObject.FindGameObjectWithTag("PlayerGladiatorsStore");


            for (int i = 1; i <= playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterSamnites; i++)
            {
                tempGladiator = Instantiate(galadiatorSamnites, galadiatorSamnites.transform.position, Quaternion.identity);
                tempGladiator.name = tempGladiator.name + Convert.ToString(i);
                tempGladiator.transform.position = new Vector2(galadiatorSamnites.transform.position.x + (i / 3.5f), galadiatorSamnites.transform.position.y - (i / 3.5f));
                tempGladiator.SetActive(true);
            }

            for (int i = 1; i <= playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo; i++)
            {
                tempGladiator = Instantiate(galadiatorMyrmilo, galadiatorMyrmilo.transform.position, Quaternion.identity);
                tempGladiator.name = tempGladiator.name + Convert.ToString(i);
                tempGladiator.transform.position = new Vector2(galadiatorMyrmilo.transform.position.x + (i / 3.5f), galadiatorMyrmilo.transform.position.y - (i / 3.5f));
                tempGladiator.SetActive(true);
            }

            for (int i = 1; i <= playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius; i++)
            {
                tempGladiator = Instantiate(galadiatorRetiarius, galadiatorRetiarius.transform.position, Quaternion.identity);
                tempGladiator.name = tempGladiator.name + Convert.ToString(i);
                tempGladiator.transform.position = new Vector2(galadiatorRetiarius.transform.position.x + (i / 3.5f), galadiatorRetiarius.transform.position.y - (i / 3.5f));
                tempGladiator.SetActive(true);
            }

            for (int i = 1; i <= playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterThraex; i++)
            {
                tempGladiator = Instantiate(galadiatorThraex, galadiatorThraex.transform.position, Quaternion.identity);
                tempGladiator.name = tempGladiator.name + Convert.ToString(i);
                tempGladiator.transform.position = new Vector2(galadiatorThraex.transform.position.x + (i / 3.5f), galadiatorThraex.transform.position.y - (i / 3.5f));
                tempGladiator.SetActive(true);
            }
        }
        

        demoThreaxPositioned = false;
        demoSamnitesPositioned = false;
        demoStartFight = false;
        samnitesLeave = false;

        

    }

    // Update is called once per frame
    void Update()
    {
        TitusMovement();
        TitusCueDisplay();
        // move to position
        if (tutorialThreax.gameObject.activeSelf == true
            && demoThreaxPositioned == false)
        {
            ThreaxMovement(demoThreaxDestination);
        }

        if (tutorialSamnites.gameObject.activeSelf == true
            && demoSamnitesPositioned == false
            && samnitesLeave == false)
        {
            SamnitesMovement(demoSamnitesDestination);
        }

        // move to fight
        if (tutorialThreax.gameObject.activeSelf == true
            && demoStartFight == true)
        {
            ThreaxMovement(demoThreaxAttackDestination);
        }

        if (tutorialSamnites.gameObject.activeSelf == true
            && demoStartFight == true)
        {
            SamnitesMovement(demoSamnitesAttackDestination);
        }

        // Samnite leave
        if (samnitesLeave == true)
        {
            SamnitesMovement(samnitesLeaveDestination);
        }


        if (Input.GetMouseButtonDown(1))
        {
            if (dialogueCue.activeSelf == true)
            {
                dialogue.SetActive(true);
                dialogueCue.SetActive(false);
            }

        }

        if (tutorialThreax.gameObject.transform.position.x == demoThreaxAttackDestination.gameObject.transform.position.x
            && tutorialThreax.gameObject.transform.position.y == demoThreaxAttackDestination.gameObject.transform.position.y)
        {
            tutorialSamnites.gameObject.GetComponent<Animator>().SetInteger("stateInt", 10);
            tutorialThreax.gameObject.GetComponent<Animator>().SetInteger("stateInt", 10);
        }

        // Samnite reached leave position
        if (tutorialSamnites.gameObject.transform.position.x == samnitesLeaveDestination.gameObject.transform.position.x
            && tutorialSamnites.gameObject.transform.position.y == samnitesLeaveDestination.gameObject.transform.position.y)
        {

            Invoke("SamnitesDespawns", 1f);
            
        }

        // Titus animation
        if (titus.gameObject.transform.position == gladiatorDestination.transform.position)
        {
            titus.gameObject.GetComponent<Animator>().SetInteger("stateInt", 0);
        }
        else
        {
            titus.gameObject.GetComponent<Animator>().SetInteger("stateInt", 1);
        }



    }

    public void TitusMovement()
    {
        float step = 3f * Time.deltaTime;
        titus.transform.position = Vector2.MoveTowards(titus.gameObject.transform.position, gladiatorDestination.position, step);
    }

    public void TitusCueDisplay()
    {
        if (titus.gameObject.transform.position == gladiatorDestination.transform.position)
        {
            if (dialogue.gameObject.activeSelf == false)
            {
                dialogueCue.SetActive(true);
            }
        }
    }

    public void ThreaxMovement(Transform destination)
    {
        float step = 5f * Time.deltaTime;
        tutorialThreax.transform.position = Vector2.MoveTowards(tutorialThreax.gameObject.transform.position, destination.position, step);
    }

    public void SamnitesMovement(Transform destination)
    {
        float step = 5f * Time.deltaTime;
        tutorialSamnites.transform.position = Vector2.MoveTowards(tutorialSamnites.gameObject.transform.position, destination.position, step);
    }

    public void DemoGladiatorsBacktoStartPosition()
    {
        demoStartFight = false;
        demoThreaxPositioned = false;
        demoSamnitesPositioned = false;
    }

    public void SamnitesDespawns()
    {
        tutorialSamnites.SetActive(false);
    }
}
