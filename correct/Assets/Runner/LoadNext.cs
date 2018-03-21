
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour {

    public void loadNext() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
