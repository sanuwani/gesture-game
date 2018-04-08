using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerCred : MonoBehaviour {

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
