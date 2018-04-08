
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Score : MonoBehaviour {

    [DllImport("GestureDetect")]
    public static extern int Detect();

    public Transform player;
    public Text scoreText;

    // Update is called once per frame
    void Update () {
        //scoreText.text = player.position.z.ToString("0");
        int b = Detect();
        if (b == 1)
        {
            scoreText.text = "Left";
        }
        if (b == 2)
        {
            scoreText.text = "Right";
        }
        if (b == 3)
        {
            scoreText.text = "Go";
        }


    }
}
