using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDataPersistence
{
    PlayerControls controls;
    public GameObject playerHuman;
    public GameObject playerAlien;
    public bool form;
    public ParticleSystem shapeshiftSmoke;
    public float maxEnergy = 3;
    public float currentEnergy;
    public Slider energyBar;
    Animator animator;
    
    void Awake()
    {
        form = false; //false is human true is alien
        //Cursor.visible = false; only enable this once we have a crosshair or something
        controls = new PlayerControls();
        controls.Player.Shapeshift.performed += ctx => Shapeshift();
        currentEnergy = 0;
        UpdateEnergyUI();
        animator = GetComponent<Animator>();
    }

    public void LoadGame(GameData data)
    {
        this.currentEnergy = data.currentEnergy;
        energyBar.value = this.currentEnergy;
        this.form = data.form;
    }

    public void SaveGame(ref GameData data)
    {
        data.currentEnergy = this.currentEnergy;
        data.currentEnergy = energyBar.value;
        data.form = this.form;
    }

    void Shapeshift()
    {
        if (form == false) // If the player is currently in human form
        {
            // Transform into an alien only if the energy level is greater than 0
            if (currentEnergy >= 3)
            {
                Instantiate(shapeshiftSmoke, transform.position, Quaternion.Euler(-90, 0, 0));
                //playerHuman.SetActive(false);
                playerAlien.SetActive(true);
                form = true;
                currentEnergy -= 3; // Decrease energy level after transformation
            }
        }
        else // If the player is currently in alien form
        {
            // Transform back into a human without any restriction
            Instantiate(shapeshiftSmoke, transform.position, Quaternion.Euler(-90, 0, 0));
            //playerHuman.SetActive(true);
            playerAlien.SetActive(false);
            form = false;
        }

        UpdateEnergyUI();
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    public void AddEnergy(int amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, 3);
        UpdateEnergyUI();
    }

    void UpdateEnergyUI()
    {
        energyBar.value = currentEnergy;
    }
}
