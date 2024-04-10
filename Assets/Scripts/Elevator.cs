using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Object targetScene;
    public bool winConditionMet = false;
    public Telekinesis telekinesis;

    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        telekinesis = player.GetComponent<Telekinesis>();
    }

    public void Update()
    {
        winConditionMet = telekinesis.leverFlipped;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && winConditionMet)
        {
            SceneManager.LoadScene("GameWin");
        }
    }
}
