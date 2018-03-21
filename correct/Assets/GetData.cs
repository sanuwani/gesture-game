using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetData : MonoBehaviour {
    public string postDataURL = "http://localhost:8080/game/php/register.php";
    private string valid;
    public GameObject nextUI;


    void Start()
    {
        /*
        WWW www = new WWW(postDataURL);
        StartCoroutine(checkValid(www));*/
    }

    
    IEnumerator checkValid(WWW www)
    {
       // WWW itemsData = new WWW(postDataURL);
        yield return www;
        valid = www.text;
        Debug.Log(valid);
        if (valid == "true")
        {
            nextUI.SetActive(true);
        }
        else
        {
            Debug.Log("wrong");
        }
    }
}
