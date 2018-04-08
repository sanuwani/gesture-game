using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class player : MonoBehaviour {

    private Rigidbody rb;
    private Animator anim;
    public float sidewaysForce;
    public Text scoreText;
    private int a;
    bool jump = false;

    [DllImport("GestureDetect")]
    public static extern int Open();

    [DllImport("GestureDetect")]
    public static extern int Detect();

    [DllImport("GestureDetect")]
    public static extern int Close();


    

    void Start () {
        anim=GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        Open();
        //rb.velocity = new Vector3(0f, 0f, 5f);
    }

    // Update is called once per frame
    void Update() {
        a = Detect();
        //Input.GetKeyDown("d")
        if (a==1 && jump==true) {
            rb.AddForce(0f, 7f, 0f, ForceMode.Impulse);
            anim.Play("Jumping");
            rb.AddForce(0f, 0f, 0f, ForceMode.Impulse);
            jump = false;
        }

        if (a==3)
        {
            //rb.velocity = new Vector3(0f, 0f, 0f);
            rb.AddForce(0f, 0f, 0f);
            rb.velocity = rb.velocity.normalized * 0f;
        }


        if (a==2)
        {
            //rb.velocity = new Vector3(0f, 0f, 5f);
            rb.AddForce(0f,0f,7f);
            jump = true;
        }
        if (rb.velocity.magnitude>7f) {
            rb.velocity = rb.velocity.normalized * 5f;
        }
        if (rb.position.y<-1f) {
           FindObjectOfType<Game>().EndGame();
            Close();
          
        }

        if (Input.GetKeyDown("escape"))
        {
            
            SceneManager.LoadScene(1);
            Close();
        }
    }


    public void Freez() {
        rb.velocity = new Vector3(0f, 0f, 0f);
        //anim.Play("victory");
        Close();
    }

    void OnApplicationQuit()
    {
        Close();
    }


}
