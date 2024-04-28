using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionButton : MonoBehaviour
{
    // Reference to the saveState script
    public saveState SaveState;

    // Function to handle button click event
    public void OnWinButtonClick()
    {
        // Set the level pass status to true based on the current scene
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "EngineRoom")
        {
            SaveState.levelOnePass = true;
        }
        else if (scene.name == "Level2")
        {
            SaveState.levelTwoPass = true;
        }
        else if (scene.name == "Observatory")
        {
            SaveState.levelThreePass = true;
        }
    }
}
