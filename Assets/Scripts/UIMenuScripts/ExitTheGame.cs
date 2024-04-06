using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTheGame : MonoBehaviour

{
    // Method to quit the game
    public void QuitGame()
    {
        // Quit the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
