using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {


    bool gameEnded = false;
    public GameObject tryAgainUI;

    public void EndGame() {

        if (gameEnded==false) {
            gameEnded = true;
            Debug.Log("Game over");
            tryAgainUI.SetActive(true);
        }
        
    }


    public void Restart() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        

       
    }

    public void completeLevel() {
        Debug.Log("completed");
    }

}
