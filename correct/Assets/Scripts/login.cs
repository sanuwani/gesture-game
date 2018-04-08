using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class login : MonoBehaviour {

    public GameObject user_id;
    public GameObject username;
    public string userid;
    public string userName;
    private string valid;
    public GameObject nextUI;
    public GameObject currentUI;
    public GameObject firstmenu;
    public GameObject errorMenu;


    public string postDataURL = "https://sanuwaniudara.000webhostapp.com/data.php";
  
    // Use this for initialization
    void Start () {
		
	}


   
    
    IEnumerator LoginButton() {
        WWWForm form = new WWWForm();
        form.AddField("useridPost", userid);
        form.AddField("usernamePost",userName);
        WWW www = new WWW(postDataURL, form);
        yield return www;
        valid = www.text;
        Debug.Log(www.text);
        if (valid == "true")
        {
            PlayerPrefs.SetString("userID", userid);
            //currentUI.SetActive(false);
            //nextUI.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else {
            showError();
        }
    }
	// Update is called once per frame
	void Update () {
        
    }

    public void submit() {
        userid = user_id.GetComponent<InputField>().text;
        userName = username.GetComponent<InputField>().text;
        if (userid != "" && userName != "")
        {
            StartCoroutine(LoginButton());
        }
        
    }



    IEnumerator LogError()
    {
        //currentUI.SetActive(false);
        errorMenu.SetActive(true);
        yield return new WaitForSeconds(3);
        errorMenu.SetActive(false);
        //currentUI.SetActive(true);
    }

    public void showError() {
        StartCoroutine(LogError());
    }




}
