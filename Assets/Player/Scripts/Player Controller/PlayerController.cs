using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public CharacterController playerController;
    public float footstepInterval = 1f;
    public float walkSpeed = 12f;
    public float runSpeed = 18f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    
    [Header("Player Grounded")]
    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    
    [Header("Crouch Management")]
    public float crouchSpeed = 2f;
    public float crouchingHeight = .85f;
    public float standingHeight = 1.65f;

    [Header("Camera FOV")]
    [SerializeField] private float cameraFOVSprint;
    [SerializeField] private float cameraFOVWalk;
    [SerializeField] private Camera camera;

    bool isGrounded;
    bool canCrouch = false;

    private float currentSpeed = 0f;
    private float currentInterval;
    private float timer = 0f;

    private float horizontal;
    private float vertical;
    
    private Vector2 input;
    private Vector3 velocity;

    void Update()
    {
        CheckIfIsCrouching();
        SettingSpeedValues();
        CheckIfPlayerIsGrounded();
        SetupPlayerInput();
        PlayerMovement();
        ControlJump();
        ControlCamFOV();
    }

    private void CheckIfIsCrouching()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!canCrouch)
            {
                canCrouch = true;
                playerController.height = crouchingHeight;
            }
            else
            {
                canCrouch = false;
                playerController.height = standingHeight;
            }
        }
    }
    
    private void SettingSpeedValues()
    {
        if (!canCrouch)
        {
            currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        }
        else
        {
            currentSpeed = crouchSpeed;
        }
    }
    
    private void CheckIfPlayerIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void SetupPlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        input = new Vector2(horizontal, vertical);
    }

    private void PlayerMovement()
    {
        if (input.sqrMagnitude > 0)
        {
            timer += Time.deltaTime;
            currentInterval = currentSpeed == runSpeed ? footstepInterval / 2 : footstepInterval;
            
            if (timer >= currentInterval && isGrounded)
            {
                timer = 0f;
            }
        }

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        playerController.Move(direction * currentSpeed * Time.deltaTime);
    }

    private void ControlJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && !canCrouch)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }

    private void ControlCamFOV()
    {
        if ((currentSpeed == runSpeed) && (horizontal != 0 || vertical != 0))
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, cameraFOVSprint, 0.05f);
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, cameraFOVWalk, 0.1f);
        }
    }
}