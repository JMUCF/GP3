using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public AudioSource music;

    // Make sure only one AudioManager exists
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Play your sound clip here
        if(music != null)
        {
            music.Play();
        }
    }

    public void DestroyAudio()
    {
        // Call this method when the play button is clicked
        Destroy(gameObject);
    }
}
