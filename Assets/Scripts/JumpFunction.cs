using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpFunction : MonoBehaviour
{
    PlayerControls controls;
    private Rigidbody rb;
    public float jumpHeight = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();
        controls.Player.Jump.performed += ctx => Jump();
    }

    void Jump()
    {
        Debug.Log("Jumping");
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
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
