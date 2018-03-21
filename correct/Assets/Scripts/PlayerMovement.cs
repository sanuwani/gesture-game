
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {


    public Rigidbody rb;
    public float forwardForce;
    public float sidewaysForce;
    private float startTime;
    private int min;
    private int sec;
    private bool finished = false;
    private int finalScore = 0;
    private string postDataURL = "http://localhost:8080/game/php/score.php";
    // Update is called once per frame




    private void Start()
    {
        startTime = Time.time;
    }
    void Update() {
    
        if (finished == true)
            return;
        float t = Time.time - startTime;
        min = (int)t / 60;
        sec = (int)t % 60;

         
        if (Input.GetKey("s")){
          //rb.velocity = new Vector3(0f, 0f, 5f);
           rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        
        if (Input.GetKey("d")) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a")) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
        }

        if (rb.position.y<-1f) {
            FindObjectOfType<GameManager>().EndGame();
        }
        
	}


    IEnumerator GetScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("scorePost", finalScore);
        form.AddField("useridPost", PlayerPrefs.GetString("userID"));
        form.AddField("gamePost", "cube");
        WWW www = new WWW(postDataURL, form);
        yield return www;
        //valid = www.text;
        Debug.Log(www.text);
    }

    public void Complete() {
        finished = true;
        Debug.Log("inside complete");
        int score = (min * 60) + sec;
        string level = SceneManager.GetActiveScene().name;
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(level, score);
        Debug.Log(level + ":" + score);
        if (level == "Level03")
        {
            
            finalScore = (PlayerPrefs.GetInt("Level01")) + (PlayerPrefs.GetInt("Level02"))+ (PlayerPrefs.GetInt("Level03"));
            StartCoroutine(GetScore());

        }
    }



    
}
