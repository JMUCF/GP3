using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveState : MonoBehaviour
{
    public bool levelOnePass = false;
    public bool levelTwoPass = false;
    public bool levelThreePass = false;
    public bool inALevel = false;

    public Telekinesis telekinesis;


    // Start is called before the first frame update
    void Start()
    {
        //telekinesis = GameObject.Find("Player").GetComponent<Telekinesis>();
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        telekinesis = GameObject.Find("Player").GetComponent<Telekinesis>();

        if (!levelOnePass)
            levelOnePass = telekinesis.leverFlipped;
        else if(levelOnePass && !levelTwoPass)
            levelTwoPass = telekinesis.leverFlipped;
        else if(levelOnePass && levelTwoPass)
            levelThreePass = telekinesis.leverFlipped;
    }
}
