using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 1f;
    private float maxSpeed = 10f;

    public float jumpHeight = 5f;
    private bool isGrounded = true; // Track if the player is grounded

    private Transform mainCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerControls = new PlayerControls();
        playerControls.Player.Jump.performed += ctx => OnJump(); // Subscribe to the jump input event
        // Assuming the camera is a child of the player, otherwise, find the camera in the scene.
        mainCameraTransform = Camera.main.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded when they collide with something
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("pickup") || collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the forward and right vectors of the camera
        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        // Project the vectors onto the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;

        // Normalize the vectors to ensure consistent speed in all directions
        forward.Normalize();
        right.Normalize();

        // Calculate the movement direction based on camera orientation
        Vector3 movement = (forward * movementY + right * movementX).normalized;

        // Apply force based on the new movement direction
        if(rb.velocity.magnitude > maxSpeed) //clamps the player speed to maxSpeed if trying to move faster than maxSpeed               ########### edit this if to make an exception when player is falling. just checking if grounded is true doesn't work since player can just bunny hop really fast. need to only allow movespeed to exceed clamp on the y-axis.
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        else
        {
            rb.AddForce(movement * speed);
        }

        // Rotate the player to match the camera's forward direction (optional)
        transform.rotation = Quaternion.LookRotation(forward);
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

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
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
}
