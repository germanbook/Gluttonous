using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    //this script is for testing purposes to show the net being launched
    //to do: set the net target as the target of the gladiators, launch the net in that direction 
    public float Speed = 4.5f;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
