using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.InteropServices;
public class Timer : MonoBehaviour {

    [DllImport("GestureDetect")]
    public static extern int Detect();


    public Text timeText;
    public Text scoreText;
    private float startTime;
    public bool finished = false;
    public int min;
    public int sec;
    private int score=0;
    private string postDataURL= "https://sanuwaniudara.000webhostapp.com/score.php";


    // Use this for initialization
    void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
 
        if (finished)
            return;
        float t = Time.time - startTime;
        min = (int)t / 60;
        sec = (int)t % 60;
        //string minute = ((int)t / 60).ToString();
        //string second = (t % 60).ToString("f2");
        //timeText.text = minute + ":" + second;
        int b = Detect();
        if (b == 1)
        {
            timeText.text = "Jump";
        }
        if (b == 3)
        {
            timeText.text = "Stop";
        }
        if (b == 2)
        {
            timeText.text = "Go";
        }
    }


    IEnumerator GetScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("scorePost", score);
        form.AddField("useridPost",PlayerPrefs.GetString("userID"));
        form.AddField("gamePost", "runner");
        WWW www = new WWW(postDataURL, form);
        yield return www;
        //valid = www.text;
        Debug.Log(www.text);
    }
   

    public void Finish() {
        finished = true;
        timeText.color = Color.yellow;
        int num = SceneManager.GetActiveScene().buildIndex;
        if (num == 8)
        {
            score = ((min * 60) + sec)*2;
            scoreText.text = score.ToString();
        }
        else {
            score = ((min * 60) + sec);
            scoreText.text = score.ToString();
        }

        //scoreVal = score.ToString();
        StartCoroutine(GetScore());
    }
}
