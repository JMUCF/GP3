using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionButton : MonoBehaviour
{
    // Reference to the saveState script
    private saveState SaveState;
    public Telekinesis telekinesis;

    public void Start()
    {
        SaveState = GameObject.Find("LevelSaveState").GetComponent<saveState>();
    }

    // Function to handle button click event
    public void OnWinButtonClick()
    {
        // Set the level pass status to true based on the current scene
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "EngineRoom")
        {
            telekinesis.leverFlipped = true;
        }
        else if (scene.name == "Level2")
        {
            telekinesis.leverFlipped = true;
        }
        else if (scene.name == "Observatory")
        {
            telekinesis.leverFlipped = true;
        }
    }

    void Update()
    {
        if(SaveState.inALevel)
        {
            telekinesis = GameObject.Find("Player").GetComponent<Telekinesis>();
            if(telekinesis == null)
                Debug.Log("uh oh");
        }
    }
}
