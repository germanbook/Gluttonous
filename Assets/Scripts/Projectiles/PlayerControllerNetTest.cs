using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNetTest : MonoBehaviour
{
    public NetBehaviour ProjectPrefab;
    public Transform LaunchOffset;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("Run",true);

            Invoke("SpawnObject", 0.6f);
        }
        else
        {
            
            animator.SetBool("Run", false);
        }

    }
    void SpawnObject()
    {
        Instantiate(ProjectPrefab, LaunchOffset.position, transform.rotation);

    }
}
