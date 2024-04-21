using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveState : MonoBehaviour
{
    public bool levelOnePass = false;
    public bool levelTwoPass = false;
    public bool levelThreePass = false;
    public bool inALevel = true;

    public Telekinesis telekinesis;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
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
            else if(levelOnePass && levelTwoPass)
            {
                Debug.Log("doesn't exist yet");
            }
        }
    }
}
