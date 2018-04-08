using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowBoard : MonoBehaviour
{

    public GameObject scoreObj;
    public GameObject scoreRoot;
    public Text textName, textScore;
    public string[] items;
    

    IEnumerator getScore(string url)
    {
        WWW itemsData = new WWW(url);
        yield return itemsData;
        string itemsDataString = itemsData.text;
        //Debug.Log(itemsDataString);
        items = itemsDataString.Split(' ');

        for (int i = 0; i < items.Length; i++)
        {
            Debug.Log(items[i]);
        }



        while (scoreRoot.transform.childCount > 0)
        {
            Destroy(scoreRoot.transform.GetChild(0).gameObject);
            yield return null;
        }

        if (items.Length < 6)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                if ((items[i] != " ") && (i % 2 == 0))
                {
                    textName.text = items[i];
                    textScore.text = items[i + 1];
                    GameObject instanceScore = Instantiate(scoreObj);
                    instanceScore.SetActive(true);
                    instanceScore.transform.SetParent(scoreRoot.transform);
                }
            }
        }


        else {
            for (int i = 0; i < 6; i++)
            {
                if ((items[i] != " ") && (i % 2 == 0))
                {
                    textName.text = items[i];
                    textScore.text = items[i + 1];
                    GameObject instanceScore = Instantiate(scoreObj);
                    instanceScore.SetActive(true);
                    instanceScore.transform.SetParent(scoreRoot.transform);
                }
            }
        }
       
    }

    public void loadScore()
    {
        StartCoroutine(getScore("https://sanuwaniudara.000webhostapp.com/scoreBoard.php"));
    }

    public void loadCubeScore()
    {
        StartCoroutine(getScore("https://sanuwaniudara.000webhostapp.com/scoreBoardCube.php"));
    }

    public void back() {
        SceneManager.LoadScene(1); 
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
