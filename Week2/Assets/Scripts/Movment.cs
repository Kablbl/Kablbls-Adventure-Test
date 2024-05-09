using UnityEngine;
using UnityEngine.UI;  // Include UI namespace for updating UI elements.

public class CharacterController3D : MonoBehaviour
{
    public float speed = 5.0f;            // Speed of the character movement
    public float jumpSpeed = 8.0f;        // Jump force
    public float gravity = 20.0f;         // Gravity applied to the character
    public float sensitivity = 100f;      // Sensitivity of the mouse movement

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public SoundManager soundManager;
    public int mangoCount = 0;  // To track the number of mangos collected
    public Text mangoCountText;  // UI Text to display the number of mangos

    private float rotationY = 0f;  // Variable to store rotation around the y-axis

    void Start()
    {
        controller = GetComponent<CharacterController>();
        UpdateMangoCountText();
    }

    void Update()
    {
        HandleMovement();
        HandleCameraControl();
    }

    private void HandleMovement()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection) * speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                if (soundManager != null)
                {
                    soundManager.PlayJumpSound();
                }
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;  // Apply gravity
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void HandleCameraControl()
    {
        // Mouse movement for horizontal rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);  // Apply rotation to the player
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mango"))
        {
            other.gameObject.SetActive(false);  // Deactivate the mango
            mangoCount++;  // Increase the count of mangos
            UpdateMangoCountText();
        }
    }

    void UpdateMangoCountText()
    {
        if (mangoCountText != null)
        {
            mangoCountText.text = "Mangos: " + mangoCount.ToString();
        }
    }
}
