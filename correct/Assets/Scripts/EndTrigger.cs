
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;
    public PlayerMovement player;
    public void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
        //meObject.Find("PlayerMovement").SendMessage("Complete");
        player.Complete();
    }
  
}
