using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check if the charactor is moving for lift or right
/// </summary>
public class PlayerPosition : MonoBehaviour
{

    private float oldPosition;


    private void Start()
    {
        oldPosition = this.gameObject.transform.position.x;
    }

    private void Update()
    {
        // Moving of right
        if (transform.position.x > oldPosition)
        {
            if (this.gameObject.tag == "Enemy")
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        // Moving of lift
        if (transform.position.x < oldPosition)
        {
            if (this.gameObject.tag == "Player")
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        // update the old position with the new position
        oldPosition = transform.position.x;
    }

}
