using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElevatorNamespace
{
    public class ElevatorTest : MonoBehaviour
    {
        private saveState saveStateScript;

        private void Start()
        {
            saveStateScript = GameObject.Find("LevelSaveState").GetComponent<saveState>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && saveStateScript != null)
            {
                if (saveStateScript.inALevel && saveStateScript.telekinesis.leverFlipped)
                {
                    saveStateScript.inALevel = false;
                    SceneManager.LoadScene("GameWin");
                }
                else if (!saveStateScript.levelOnePass)
                {
                    saveStateScript.inALevel = true;
                    SceneManager.LoadScene("EngineRoomLevel (1)");
                }
                else if (saveStateScript.levelOnePass && !saveStateScript.levelTwoPass)
                {
                    saveStateScript.inALevel = true;
                    SceneManager.LoadScene("HubTutorialRoom");
                }
                else if (saveStateScript.levelOnePass && saveStateScript.levelTwoPass)
                {
                    Debug.Log("Level doesn't exist yet");
                }
            }
        }
    }
}
