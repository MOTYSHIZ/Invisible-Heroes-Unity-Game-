using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour
{
    public int lightSpeed;                  //Speed of light, heh. (Negative direction is possible)

    //public Vector3 centerOfRotation;      //Used to move axis point... no obvious change noticed.

    public enum lightDir { vertical, horizontal };
    public lightDir axisOfRotation;

    Vector3 axis;
    void Update()
    {
        //Choosing axis of rotation
        if (axisOfRotation == lightDir.vertical)
        {
            axis = Vector3.up;
        }
        else if (axisOfRotation == lightDir.horizontal)
        {
            axis = Vector3.left;
        }
        transform.RotateAround(Vector3.zero, axis, lightSpeed * Time.deltaTime);    //Rotating around a point
    }
}