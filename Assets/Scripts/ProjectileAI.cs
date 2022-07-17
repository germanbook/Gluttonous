using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  ProjectileAI : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {

    }

    

// Update is called once per frame
    void Update()
    {
        

    }
    /*public void TargetPosition()
    {
        targetPosition = targetDummy.transform.position - this.transform.position;

    }
    public void ThrowProjectile()
    {
        TargetPosition();
        Debug.Log("This is the targets position: " + targetPosition);
        projectileInstance = Instantiate(spear, armLaunchArea.transform.position, transform.rotation);

        *//*            CalculateAngle();
        *//*
    }
    public void GrabTargetCoordinates(Vector2 coordinates)
    {
        projectileVector = coordinates;
        Debug.Log("this is the projectile vector" + projectileVector);
    }
    void TargetCoordinate()
    {
        Vector3 gladiatorPosition = this.transform.position;
        Vector3 fuelPosition = targetDummy.transform.position;

        float distance = Vector3.Distance(gladiatorPosition, fuelPosition);

        Debug.Log("Distance: " + distance);
    }
    void CalculateAngle()
    {
        Vector3 VerticalLine = this.transform.up;
        Vector3 positionOfTarget = targetPosition;
        float angle = Vector3.Angle(VerticalLine, positionOfTarget);
        Debug.Log("This is the angle" + angle);

        Debug.DrawRay(this.transform.position, VerticalLine * 50, Color.green, 2, false);
        Debug.DrawRay(this.transform.position, positionOfTarget * 50, Color.red, 2, false);

        *//*     int clockwise = 1;
            if (Cross(VerticalLine, positionOfTarget).z < 0)
                clockwise = -1;*//*
    }
    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.z * w.x - v.x * w.z;
        float zMult = v.x * w.y - v.y * w.x;

        Vector3 crossProduct = new Vector3(xMult, yMult, zMult);
        return crossProduct;
    }*/
}

