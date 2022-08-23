using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorSelector : MonoBehaviour
{

    [SerializeField] GameObject galadiatorSamnites;
    [SerializeField] GameObject galadiatorThraex;
    [SerializeField] GameObject galadiatorMyrmilo;
    [SerializeField] GameObject galadiatorRetiarius;

    private GameObject playerGladiatorsStore;

    private GameObject tempGladiator;

    // Start is called before the first frame update
    void Start()
    {
        // gladiator store
        playerGladiatorsStore = GameObject.FindGameObjectWithTag("PlayerGladiatorsStore");

        Debug.Log("LudusSceneManager");
        Debug.Log("counterSamnites " + playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterSamnites);
        Debug.Log("counterMyrmilo " + playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterMyrmilo);
        Debug.Log("counterRetiarius " + playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterRetiarius);
        Debug.Log("counterThraex " + playerGladiatorsStore.GetComponent<PlayerGladiatorsStore>().counterThraex);

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

    // Update is called once per frame
    void Update()
    {

    }
}
