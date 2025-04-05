using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    [Header("Look Settings")]
    public float mouseSensitivity = 100f;
    public float maxLookAngle = 90f;

    private CharacterController characterController;
    private Camera playerCamera;
    private Vector3 velocity;
    private float xRotation = 0f;
    private bool isGrounded;
    private float stepCycle;
    private float nextStep;
    private bool wasMoving ;
    private AudioSource audioSource;
    public AudioClip[] footstepSounds;
    public float walkStepInterval = 0.5f;
    public float runStepInterval = 0.3f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
        ProgressStepCycle();
    }

    void HandleMovement()
    {
        
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        // 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // 
        Vector3 move = transform.right * x + transform.forward * z;

        // 
        characterController.Move(move * currentSpeed * Time.deltaTime);
        wasMoving = move.magnitude > 0.1f && isGrounded;
        // 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

        //
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); // 
    }
    private void ProgressStepCycle()
    {
        if (characterController.velocity.sqrMagnitude > 0 && wasMoving)
        {
            stepCycle += (characterController.velocity.magnitude + (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed)) * Time.deltaTime;
        }
        if (wasMoving == false)
        {
            audioSource.clip = null;
        }
        if (!(stepCycle > nextStep))
        {
           
            return;
        }

        nextStep = stepCycle + (Input.GetKey(KeyCode.LeftShift) ? runStepInterval : walkStepInterval);

        PlayFootStepAudio();
    }

    private void PlayFootStepAudio()
    {
        if (!isGrounded )
        {
            return;
        }

        // Pick a random footstep sound from the array
        audioSource.clip = footstepSounds[0];
        audioSource.Play();
        Debug.Log("audio:"+ audioSource.clip.name);
       // audioSource.PlayOneShot(audioSource.clip, footstepVolume);
        // Move picked sound to index 0 so it's not picked next time
    }
}