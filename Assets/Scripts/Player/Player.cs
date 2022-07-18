using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Speed")]
    [SerializeField]float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        float moveHorizongtalAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveVerticalAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveHorizongtalAmount, 0, 0);
        transform.Translate(0, moveVerticalAmount, 0);
    }
}
