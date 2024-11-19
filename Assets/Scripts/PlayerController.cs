using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Speed of player movement
    public float jumpForce = 5f; // Jump force
    public float gravity = 9.8f; // Gravity applied to the player

    [Header("Camera Settings")]
    public Camera playerCamera; // Reference to the player's camera
    public float mouseSensitivity = 2f; // Mouse sensitivity
    public float maxLookAngle = 90f; // Maximum vertical look angle

    private CharacterController characterController;
    private Vector3 velocity; // For tracking vertical movement

    private float rotationX = 0f; // Rotation on the X-axis

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Handle player movement
        MovePlayer();

        // Handle camera rotation
        RotateCamera();
    }

    void MovePlayer()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveZ = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        // Calculate movement direction relative to the player's orientation
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply movement
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Apply gravity
        if (characterController.isGrounded)
        {
            velocity.y = -2f; // Small downward force to keep grounded
            if (Input.GetButtonDown("Jump")) // Space key for jump
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime; // Apply gravity when not grounded
        }

        // Apply vertical movement
        characterController.Move(velocity * Time.deltaTime);
    }

    void RotateCamera()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player on the Y-axis (horizontal rotation)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera on the X-axis (vertical rotation)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxLookAngle, maxLookAngle); // Clamp vertical rotation

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
