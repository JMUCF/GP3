using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpFunction : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody rb;
    public float jumpHeight = 5f;
    private bool isGrounded = true; // Track if the player is grounded

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerControls = new PlayerControls();
        playerControls.Player.Jump.performed += ctx => OnJump(); // Subscribe to the jump input event
    }

    void OnEnable()
    {
        if (playerControls != null)
            playerControls.Enable();
    }

    void OnDisable()
    {
        if (playerControls != null)
            playerControls.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded when they collide with something
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnJump()
    {
        // Check if the player is grounded before allowing them to jump
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false; // Player is no longer grounded after jumping
        }
    }
}