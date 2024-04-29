using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetSave : MonoBehaviour
{
    public Button resetButton;
    private saveState saveStateScript;
    public GameObject resetText;
    void Start()
    {
        resetButton.onClick.AddListener(ResetStuff);
        saveStateScript = GameObject.Find("LevelSaveState").GetComponent<saveState>();
    }

    void ResetStuff()
    {
        saveStateScript.levelOnePass = false;
        saveStateScript.levelTwoPass = false;
        saveStateScript.levelThreePass = false;
        StartCoroutine("showText");
    }

    private IEnumerator showText()
    {
        resetText.SetActive(true);
        yield return new WaitForSeconds(2f);
        resetText.SetActive(false);
    }
}
