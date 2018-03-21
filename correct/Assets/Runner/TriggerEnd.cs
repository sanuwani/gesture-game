using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour {

    public Game game;
    public GameObject scoreUI;


    private void OnTriggerEnter()
    {
        GameObject.Find("player").SendMessage("Finish");
        GameObject.Find("player").SendMessage("Freez");
        Invoke("GameEnd",2f);

    }

    public void GameEnd() {
        scoreUI.SetActive(true);
    }
   
}
