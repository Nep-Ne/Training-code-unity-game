using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Ultilis 
{
    static public Vector3 AngleToVector(float angle)
    {
        float angleRadian=angle*Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angleRadian),Mathf.Sin(angleRadian));
    }


    static public float VectorToAngle(Vector3 direction)
    {
        
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle +=360 ;
        }
        return angle;
    }

    static public Vector3 ToVector3(Vector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y);
    }
}
