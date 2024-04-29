using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBarrier : MonoBehaviour
{
    private saveState saveStateScript;

    // Start is called before the first frame update
    void Start()
    {
        saveStateScript = GameObject.Find("LevelSaveState").GetComponent<saveState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Level2Barrier" && saveStateScript.levelOnePass)
        {
            gameObject.SetActive(false);
        }

        else if (gameObject.name == "Level3Barrier" && saveStateScript.levelTwoPass)
        {
            gameObject.SetActive(false);
        }
    }
}
