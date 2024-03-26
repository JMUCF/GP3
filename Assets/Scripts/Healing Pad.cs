using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPad : MonoBehaviour
{
    public float healAmount = 25f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthBar playerHealth = collision.gameObject.GetComponent<HealthBar>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }
        }
    }
}
