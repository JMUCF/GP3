using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayTheGame : MonoBehaviour
{
    bool isMainSceneActive = true;

    // Reference to the UI button in the inspector
    public Button switchSceneButton;

    void Start()
    {
        // Add a listener to the button so that the SwitchScenes method is called when the button is clicked
        switchSceneButton.onClick.AddListener(SwitchScenes);
    }

    void SwitchScenes()
    {
        if (isMainSceneActive)
        {
            SceneManager.LoadScene("EngineRoomLevel (1)");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }

        isMainSceneActive = !isMainSceneActive;
    }
}
