using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveState : MonoBehaviour
{
    private static saveState instance;

    public bool levelOnePass = false;
    public bool levelTwoPass = false;
    public bool levelThreePass = false;
    public bool inALevel = true;

    public Telekinesis telekinesis;

    // Make sure only one saveState exists
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(inALevel)
        {
            telekinesis = GameObject.Find("Player").GetComponent<Telekinesis>();
            if(telekinesis == null)
                Debug.Log("uh oh");

            if (scene.name == "EngineRoom")
            {
                levelOnePass = telekinesis.leverFlipped;
            }
            else if(scene.name == "Level2")
            {
                levelTwoPass = telekinesis.leverFlipped;
            }
            else if(scene.name == "Observatory")
            {
                levelThreePass = telekinesis.leverFlipped;
            }
        }
    }
}
