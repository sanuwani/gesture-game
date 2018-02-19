using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {

    public string [] items;
	// Use this for initialization
	IEnumerator Start () {
        WWW itemsData = new WWW("http://localhost:8080/game/php/data.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        items = itemsDataString.Split('/');

        for (int i=0;i<items.Length;i++) {
            print (items[i]);
        }
	}
	
	
}
