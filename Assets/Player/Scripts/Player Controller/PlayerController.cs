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
    [SerializeField] private float CameraFOVSprint;
    [SerializeField] private float CameraFOVWalk;
    [SerializeField] private Camera camera;

    Vector3 _velocity;
    bool _isGrounded;
    bool _canCrouch = false;

    private float currentSpeed = 0f;
    private float currentInterval;
    private float timer = 0f;
    private Vector2 input;

    void Update()
    {
        CheckIfIsCrouching();
        SettingSpeedValues();
        CheckIfPlayerIsGrounded();
        PlayerControls();
        ControlCamFOV();
    }

    private void CheckIfIsCrouching()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!_canCrouch)
            {
                _canCrouch = true;
                playerController.height = crouchingHeight;
            }
            else
            {
                _canCrouch = false;
                playerController.height = standingHeight;
            }
        }
    }
    
    private void SettingSpeedValues()
    {
        if (!_canCrouch)
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
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
    }

    private void PlayerControls()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        input = new Vector2(horizontal, vertical);

        if (input.sqrMagnitude > 0)
        {
            timer += Time.deltaTime;
            currentInterval = currentSpeed == runSpeed ? footstepInterval / 2 : footstepInterval;
            if (timer >= currentInterval && _isGrounded)
            {
                timer = 0f;
            }
        }

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        playerController.Move(direction * currentSpeed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && _isGrounded && !_canCrouch)
        {
            _velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;
        playerController.Move(_velocity * Time.deltaTime);
    }

    private void ControlCamFOV()
    {
        if (currentSpeed == runSpeed)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, CameraFOVSprint, 0.05f);
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, CameraFOVWalk, 0.05f);
        }
    }
}