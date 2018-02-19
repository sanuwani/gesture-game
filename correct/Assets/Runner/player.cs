using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    private Rigidbody rb;
    private Animator anim;
    public float sidewaysForce;

    void Start () {
        anim=GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
       rb.velocity = new Vector3(0f,0f,5f);
	}

    // Update is called once per frame
    void Update() {

        
        if (Input.GetKeyDown("d")) {
            rb.AddForce(0f, 7f, 0f, ForceMode.Impulse);
            anim.Play("Jumping");
        }

        if (Input.GetKeyDown("a"))
        {
            //rb.AddForce(0f, 7f, 0f, ForceMode.Impulse);
            anim.Play("down");
        }

        //float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime*moveSpeed;
        //transform.Translate(speed,0,1*spd);

        /*if (Input.GetKey("s")&& (transform.position.x<1.88))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }
        if (Input.GetKey("a") && (transform.position.x < -1.88))
        {
            //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }*/


    }
}
