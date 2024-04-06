using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    // Reference to the UI Button in the inspector
    public Button switchToMainButton;

    void Start()
    {
        // Add a listener to the button so that the SwitchToMain method is called when the button is clicked
        switchToMainButton.onClick.AddListener(SwitchToMain);
    }

    void SwitchToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
