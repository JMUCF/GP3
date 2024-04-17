using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public bool winConditionMet = false;
    //public bool inALevel;
    private saveState saveStateScript;

    public void Start()
    {
        saveStateScript = GameObject.Find("LevelSaveState").GetComponent<saveState>();
    }

    public void Update()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (saveStateScript.inALevel && saveStateScript.telekinesis.leverFlipped)
        {
            saveStateScript.inALevel = false;
            SceneManager.LoadScene("GameWin");
        }
        else if (!saveStateScript.levelOnePass)
        {
            saveStateScript.inALevel = true;
            SceneManager.LoadScene("EngineRoomLevel (1)");
        }
        else if (saveStateScript.levelOnePass && !saveStateScript.levelTwoPass)
        {
            saveStateScript.inALevel = true;
            SceneManager.LoadScene("NewEnemyTest");
        }
        else if (saveStateScript.levelOnePass && saveStateScript.levelTwoPass)
            Debug.Log("Level doesn't exist yet");

    }
}
