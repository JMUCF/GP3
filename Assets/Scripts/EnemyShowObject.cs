using UnityEngine;

namespace MyNamespace
{
    public class EnemyShowObject : MonoBehaviour
    {
        public bool isDefeated = false;

        // Method to handle defeating the BossBot
        public void Defeat()
        {
            // Perform any necessary actions when BossBot is defeated
            isDefeated = true;
        }
    }
}
