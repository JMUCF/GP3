using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    private saveState saveStateScript;

    public void Start()
    {
        saveStateScript = GameObject.Find("LevelSaveState").GetComponent<saveState>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (saveStateScript.inALevel && saveStateScript.telekinesis.leverFlipped)
            {
                saveStateScript.inALevel = false;
                SceneManager.LoadScene("GameWin");
            }
            else if (!saveStateScript.levelOnePass)
            {
                saveStateScript.inALevel = true;
                SceneManager.LoadScene("EngineRoom");
            }
            else if (saveStateScript.levelOnePass && !saveStateScript.levelTwoPass)
            {
                saveStateScript.inALevel = true;
                SceneManager.LoadScene("Level2");
            }
            else if (saveStateScript.levelOnePass && saveStateScript.levelTwoPass && !saveStateScript.levelThreePass)
            {
                saveStateScript.inALevel = true;
                SceneManager.LoadScene("Observatory");
            }
            else
                Debug.Log("All levels complete");
    }
    }
}
