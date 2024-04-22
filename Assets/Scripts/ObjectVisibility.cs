using UnityEngine;

namespace MyNamespace
{
    public class ObjectVisibility : MonoBehaviour
    {
        public GameObject objectToShow;
        public GameObject bossBotEnemy;

        void Update()
        {
            // Check if the BossBot enemy exists and is defeated
            if (bossBotEnemy != null && !bossBotEnemy.activeSelf)
            {
                objectToShow.SetActive(true);
                // Optionally disable this script or remove the reference to bossBotEnemy
                enabled = false;
            }
            else
            {
                objectToShow.SetActive(false);
            }
        }
    }
}
