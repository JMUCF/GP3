using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hubElevators : MonoBehaviour
{

    public bool levelOneComplete = false;
    private saveState saveStateScript;

    // Start is called before the first frame update
    void Start()
    {
        saveStateScript = GameObject.Find("LevelSaveState").GetComponent<saveState>();
        levelOneComplete = saveStateScript.levelOnePass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
