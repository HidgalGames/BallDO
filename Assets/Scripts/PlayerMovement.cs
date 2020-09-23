using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    private Animator animator;

    [Space]
    public float maxSpeed = 6f;
    public float accelerationTime = 3f;
    public float stoppingTime = 5f;
    [SerializeField] private float currentSpeed = 0f;
    private float targetSpeed = 0f;
    private float targetTime = 0f;

    [HideInInspector] public Vector3 direction;

    [Space]
    public Button JumpButton;
    public float jumpForce = 4f;
    public ParticleSystem JumpParicles;
    public AudioClip jumpSound;

    private AudioSource aSource;
    private Rigidbody rigid;
    private bool isGrounded = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float delta = Time.deltaTime;

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 0.53f);

        JumpButton.interactable = isGrounded;

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, delta * targetTime);

        rigid.AddForce(direction * currentSpeed, ForceMode.Acceleration);
    }

    public void OnJoystickMove()
    {
        float horizontal = joystick.Horizontal;
        float vertical = 0f;

        if (isGrounded)
        {
            vertical = joystick.Vertical;
        }

        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude < 0.1f)
        {
            targetSpeed = 0f;
            targetTime = stoppingTime;
        }
        else
        {
            targetSpeed = maxSpeed;
            targetTime = 1 / accelerationTime;
        }
    }

    public void OnJoystickStop()
    {
        float horizontal = joystick.Horizontal;
        float vertical = 0f;

        if (isGrounded)
        {
            vertical = joystick.Vertical;
        }

        direction = new Vector3(horizontal, 0f, vertical).normalized;

        targetSpeed = 0f;
        targetTime = stoppingTime;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public Rigidbody GetRigidbody()
    {
        return rigid;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            aSource.PlayOneShot(jumpSound);
            JumpParicles.transform.position = transform.position;
            JumpParicles.Play();
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
