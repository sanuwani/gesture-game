
using UnityEngine;
using System.Runtime.InteropServices;

public class PlayerCollision : MonoBehaviour {

    [DllImport("GestureDetect")]
    public static extern int Close();

    public PlayerMovement movement;
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag=="Obstacle") {
            Close();
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        } 
    }
}
