using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendData : MonoBehaviour {


    public string postDataURL = "https://sanuwaniudara.000webhostapp.com/data.php";
    private string valid;
    public GameObject nextUI;

    public void Valid()
    {
        StartCoroutine(checkValid());
    }


    IEnumerator checkValid()
    {
        WWW itemsData = new WWW(postDataURL);
        yield return itemsData;
        valid = itemsData.text;
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
