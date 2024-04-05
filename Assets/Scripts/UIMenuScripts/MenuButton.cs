using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Index of the current scene
    private int currentSceneIndex = 0;

    // Array of scene names
    public string[] sceneNames = { "MainMenu", "Credits" };

    // Method to switch to the next scene
    public void NextScene()
    {
        // Increment the current scene index
        currentSceneIndex++;

        // Wrap around if reaching the end of the scene array
        if (currentSceneIndex >= sceneNames.Length)
        {
            currentSceneIndex = 0;
        }

        // Load the next scene
        SceneManager.LoadScene(sceneNames[currentSceneIndex]);
    }

    // Method to switch to the previous scene
    public void PreviousScene()
    {
        // Decrement the current scene index
        currentSceneIndex--;

        // Wrap around if reaching the beginning of the scene array
        if (currentSceneIndex < 0)
        {
            currentSceneIndex = sceneNames.Length - 1;
        }

        // Load the previous scene
        SceneManager.LoadScene(sceneNames[currentSceneIndex]);
    }
}

