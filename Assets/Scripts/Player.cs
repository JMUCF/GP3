using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerControls controls;
    public GameObject playerHuman;
    public GameObject playerAlien;
    private bool form;
    public ParticleSystem shapeshiftSmoke;
    
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

    }

    void Shapeshift()
    {
        if(form == false)
        {
            Instantiate(shapeshiftSmoke, transform.position, Quaternion.Euler(-90, 0, 0));
            playerHuman.SetActive(false);
            playerAlien.SetActive(true);
            form = true;
        }
        else
        {
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
}
