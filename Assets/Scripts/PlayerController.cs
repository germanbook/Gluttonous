using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Vector2 lastClickedPos;

    bool moving;

    public Animator animator;
    private float oldPosition;

    //Main camera assigned variable
    Camera cam;
    private void Update()
    {
        // Player can not moving while dialogue is showing
        if (Input.GetMouseButtonDown(1) && !GameManager.isDialogueShowing) {
            lastClickedPos = cam.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        
        if (moving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        } else
        {
            moving = false;
        }

        // Standing
        if (transform.position.x == oldPosition)
        {
            if (LudusSceneManager.demoStartFight == false)
            {
                // idle
                animator.SetInteger("state", 0);
            }

        }

        // Moving of right
        if (transform.position.x > oldPosition)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetInteger("state", 1);
        }

        // Moving of lift
        if (transform.position.x < oldPosition)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetInteger("state", 1);
        }

        // update the old position with the new position
        oldPosition = transform.position.x;

    }
    void Start()
    {
        //Assigns camera to variable
        cam = Camera.main;

        oldPosition = this.gameObject.transform.position.x;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "tavenWall")
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            lastClickedPos = this.gameObject.transform.position;
        }
    }
        

}
