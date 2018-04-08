using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerTest : MonoBehaviour {

    public float speed;
    public MovementTest movement;
	// Use this for initialization
	void Start () {
        movement = new MovementTest(speed);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += movement.movementCalc(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),Time.deltaTime);
	}
}
