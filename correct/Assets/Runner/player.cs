using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
    private Rigidbody rb;
    private Animator anim;
    public float sidewaysForce;
    public Text scoreText;

    void Start () {
        anim=GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(0f, 0f, 5f);
    }

    // Update is called once per frame
    void Update() {

        
        if (Input.GetKeyDown("d")) {
            rb.AddForce(0f, 7f, 0f, ForceMode.Impulse);
            anim.Play("Jumping");
        }

        if (Input.GetKeyDown("a"))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }


        if (Input.GetKeyDown("s"))
        {
            rb.velocity = new Vector3(0f, 0f, 5f);
        }

        if (rb.position.y<-1f) {
           FindObjectOfType<Game>().EndGame();
          
        }
    }


    public void Freez() {
        rb.velocity = new Vector3(0f, 0f, 0f);
        //anim.Play("victory");
    }

    
}
