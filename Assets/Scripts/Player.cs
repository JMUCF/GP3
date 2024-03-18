using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    PlayerControls controls;
    public GameObject playerHuman;
    public GameObject playerAlien;
    private bool form;
    public ParticleSystem shapeshiftSmoke;
    private int energyLevel = 0;
    public TMP_Text energyText;
    
    void Awake()
    {
        form = false; //false is human true is alien
        //Cursor.visible = false; only enable this once we have a crosshair or something
        controls = new PlayerControls();
        controls.Player.Shapeshift.performed += ctx => Shapeshift();
    }

    // Update is called once per frame
    void Update()
    {
        energyText.text = "Energy Level: " + energyLevel.ToString();
    }

    void Shapeshift()
    {
        if (form == false) // If the player is currently in human form
        {
            // Transform into an alien only if the energy level is greater than 0
            if (energyLevel >= 3)
            {
                Instantiate(shapeshiftSmoke, transform.position, Quaternion.Euler(-90, 0, 0));
                playerHuman.SetActive(false);
                playerAlien.SetActive(true);
                form = true;
                energyLevel-= 3; // Decrease energy level after transformation
            }
        }
        else // If the player is currently in alien form
        {
            // Transform back into a human without any restriction
            Instantiate(shapeshiftSmoke, transform.position, Quaternion.Euler(-90, 0, 0));
            playerHuman.SetActive(true);
            playerAlien.SetActive(false);
            form = false;
        }
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
        energyLevel += amount;
        energyLevel = Mathf.Clamp(energyLevel, 0, 3);
    }
}
