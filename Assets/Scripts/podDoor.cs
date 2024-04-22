using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podDoor : MonoBehaviour
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
        if(saveStateScript.levelThreePass)
        {
            gameObject.SetActive(false);
        }
    }
}
