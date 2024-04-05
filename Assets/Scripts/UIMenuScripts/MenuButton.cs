using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // The name of the scene to load
    public string sceneName;

    // Method to switch scenes
    public void SwitchScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }

    // Method to switch back to the previous scene
    public void SwitchBack()
    {
        // Get the index of the current scene
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the scene with the index before the current one
        SceneManager.LoadScene(currentIndex - 1);
    }
}
