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
        Debug.Log("gameObject name: " + gameObject.name);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("gameObject name: " + gameObject.name);
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
            else if (saveStateScript.levelOnePass && !saveStateScript.levelTwoPass && gameObject.name == "Elevator2Hub")
            {
                saveStateScript.inALevel = true;
                SceneManager.LoadScene("Level2");
            }
            else if (saveStateScript.levelOnePass && saveStateScript.levelTwoPass && !saveStateScript.levelThreePass && gameObject.name == "Elevator3Hub")
            {
                saveStateScript.inALevel = true;
                SceneManager.LoadScene("Observatory");
            }
            else
                Debug.Log("All levels complete");
    }
    }
}
