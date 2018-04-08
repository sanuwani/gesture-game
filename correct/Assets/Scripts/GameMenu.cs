using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour {

    public void playCubethone() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void playRunner()
    {
        SceneManager.LoadScene(7);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(1);
        }
    }
    private void Start()
    {
        //AudioManager.Instance.gameObject.GetComponent<AudioSource>().Pause();



    }
}
