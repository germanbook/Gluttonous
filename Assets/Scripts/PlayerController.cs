using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Vector2 lastClickedPos;

    bool moving;

    //Main camera assigned variable
    Camera cam;
    private void Update()
    {
        // Player can not moving while dialogue is showing
        if (Input.GetMouseButtonDown(1) && !GameManager.isDialogueShowing) {
            lastClickedPos = cam.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
        
        if (moving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        } else
        {
            moving = false;
        }
    }
    void Start()
    {
        //Assigns camera to variable
        cam = Camera.main;
    }


}
