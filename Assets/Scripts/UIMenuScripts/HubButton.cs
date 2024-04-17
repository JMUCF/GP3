using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubButton : MonoBehaviour
{
    // Reference to the UI Button in the inspector
    public Button switchToHubButton;

    void Start()
    {
        // Add a listener to the button so that the SwitchToMain method is called when the button is clicked
        switchToHubButton.onClick.AddListener(SwitchToMain);
    }

    void SwitchToMain()
    {
        SceneManager.LoadScene("HubTutorialRoom");
    }
}
