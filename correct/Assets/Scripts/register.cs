using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class register : MonoBehaviour {

    public GameObject regID;
    public GameObject regName;
    public string id;
    public string regname;
    private string valid;
    public GameObject nextUI;
    public GameObject currentUI;
    public GameObject errorMenu;
    public GameObject regMenu;
    //public Button RegButton;
    public string postDataURL = "http://localhost:8080/game/php/register.php";
    //public GetData data;

    // Use this for initialization
    void Start () {
       
    }


    IEnumerator RegisterButton()
    {
        Debug.Log("inside register");
        WWWForm form = new WWWForm();
        form.AddField("regidPost", id);
        form.AddField("regnamePost", regname);
        WWW www = new WWW(postDataURL, form);
        yield return www;
        valid = www.text;
        Debug.Log(valid);
        if (valid == "true")
        {
            currentUI.SetActive(false);
            nextUI.SetActive(true);
        }
        else {
            showError();
        }
    }

    // Update is called once per frame
    void Update () {
        


    }


    public void submit()
    {
        Debug.Log("inside button");
        id = regID.GetComponent<InputField>().text;
        regname = regName.GetComponent<InputField>().text;
        if (id!="" && regname!="") {
            StartCoroutine(RegisterButton());
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

    public void showError()
    {
        StartCoroutine(LogError());
    }

}

   
