using UnityEngine;

public class DeleteAudioManager : MonoBehaviour
{
    void Start()
    {
        // Find all game objects named "AudioManager" in the scene
        GameObject[] audioManagers = GameObject.FindGameObjectsWithTag("AudioManager");

        // Delete all found "AudioManager" game objects
        foreach (GameObject audioManager in audioManagers)
        {
            Destroy(audioManager);
        }
    }
}
