using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayTheGame : MonoBehaviour

{
    public string scene1Name = "Scene1";
    public string scene2Name = "Scene2";
    private bool isScene1Active = true; // Flag to track which scene is currently active

    // Function to handle button click event to switch scenes
    public void ToggleScenes()
    {
        // Toggle between scenes based on the current active scene
        if (isScene1Active)
        {
            SceneManager.LoadScene(scene2Name);
        }
        else
        {
            SceneManager.LoadScene(scene1Name);
        }

        // Update the flag to reflect the new active scene
        isScene1Active = !isScene1Active;
    }
}
