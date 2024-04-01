using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Object targetScene;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) // add a component probably in gamemanager of "win condition met" so the elevator will only work if the player has acheived the win condition for that level
        {
            SceneManager.LoadScene(targetScene.name);
        }
    }
}
