
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Credit : MonoBehaviour {

    public Text scoreText;
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit..");
    }

    public void LoadMenu() {
        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        int score = PlayerPrefs.GetInt("finalscore");
        scoreText.text = score.ToString();
    }
}
