using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 1;

    private Transform mainCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Assuming the camera is a child of the player, otherwise, find the camera in the scene.
        mainCameraTransform = Camera.main.transform;
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
        rb.AddForce(movement * speed);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
