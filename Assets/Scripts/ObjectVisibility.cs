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
            if (bossBotEnemy == null)
                objectToShow.SetActive(true);
        }
    }
}
