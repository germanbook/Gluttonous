using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Vector2 lastClickedPos;

    bool moving;

    [SerializeField]
    Camera cam;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            lastClickedPos = cam.ScreenToWorldPoint(Input.mousePosition);
        moving = true;

        if (moving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        } else
        {
            moving = false;
        }
    }
    private void Awake()
    {
        moving = false;
    }

}
