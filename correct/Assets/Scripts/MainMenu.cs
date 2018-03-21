using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void exit() {
        //Application.Quit();
    }

    public void viewScore() {
        SceneManager.LoadScene(9);
    }
	
}
