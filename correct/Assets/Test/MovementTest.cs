using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour {

    public float speed;
    // Use this for initialization
    public MovementTest(float sp) {
        speed = sp;
    }

    public Vector3 movementCalc(float a, float b, float deltaTime)
    {

        var x = a * speed * deltaTime;
        var z = b * speed * deltaTime;
        return new Vector3(x, 0, z);
    }
}
