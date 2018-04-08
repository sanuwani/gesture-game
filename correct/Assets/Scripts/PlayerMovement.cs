
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class PlayerMovement : MonoBehaviour {

    [DllImport("GestureDetect")]
    public static extern int Open();

    [DllImport("GestureDetect")]
    public static extern int Detect();

    [DllImport("GestureDetect")]
    public static extern int Close();


    public Rigidbody rb;
    public float forwardForce;
    public float sidewaysForce;
    private float startTime;
    private int min;
    private int sec;
    private bool finished = false;
    private int finalScore = 0;
    private string postDataURL = "https://sanuwaniudara.000webhostapp.com/score.php";
    private int a;
    // Update is called once per frame




    private void Start()
    {
        Open();
        startTime = Time.time;
        PlayerPrefs.SetInt("finalscore", finalScore);
    }
    void Update() {

        a = Detect();
        if (finished == true)
            return;
        float t = Time.time - startTime;
        min = (int)t / 60;
        sec = (int)t % 60;
   
         
        if (a==3){
          //rb.velocity = new Vector3(0f, 0f, 5f);
           rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        
        if (a==2) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
        }
        if (a==1) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
        }

        if (rb.position.y<-1f) {
            FindObjectOfType<GameManager>().EndGame();
            Close();
        }

        if (Input.GetKeyDown("escape"))
        {
            Close();
            SceneManager.LoadScene(2);
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
        Close();
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
            PlayerPrefs.SetInt("finalscore", finalScore);
            StartCoroutine(GetScore());

        }
    }

    void OnApplicationQuit() {
        Close();
    }


}
