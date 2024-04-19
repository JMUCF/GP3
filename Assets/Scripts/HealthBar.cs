using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.Common;

public class HealthBar : MonoBehaviour//, IDataPersistence
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    /*
    public void LoadGame(GameData data)
    {
        this.currentHealth = data.currentHealth;

    }

    public void SaveGame(GameData data)
    {
        data.currentHealth = this.currentHealth;
    }
    */

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }

    void Die()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("GameLose");

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("laser"))
        {
            TakeDamage(5);
        }
    }
}
