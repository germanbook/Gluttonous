using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Control the main camera functions that help the player manipulate and control where they are looking in the game world.
    /// </summary>
    
    //Global variables
    [SerializeField] 
    private Camera cam;

    [SerializeField]
    private float zoomAmount, minCamSize, maxCamSize;

    private Vector3 dragOrigin;

    private void Update()
    {
        PanCamera();
        ZoomCamera();
    }
    private void PanCamera() //Pans camera on primary mouse button click & hold
    {
        //Save position of mouse in world space when drag start (first time clicked)

        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        //Calculate distance between drag origin and new position if it is still held down
        
        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            //Displays position data
            //print("origin " + dragOrigin + " newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference " + difference);

            cam.transform.position += difference;
        }
    }
    //Zooms the camera in and out using the scrollwheel
    public void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        { 
            ZoomOut();
        }
    }
    //Camera Zoom in & out functions 
    public void ZoomIn()
    {
        float newSize = cam.orthographicSize + zoomAmount;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
    public void ZoomOut()
    {
        float newSize = cam.orthographicSize - zoomAmount;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
}
