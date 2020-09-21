using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    private AudioSource aSource;
    public Transform camTransform;
    public GameObject explosion;
    private Rigidbody rigidbody;

    public float maxSpeed = 4f;
    public float accelerationSpeed = 3f;

    [Space]
    public AudioClip shootSound;
    public AudioClip explodeSound;
    public AudioClip jumpSound;

    [Space]
    public bool isGrounded = false;
    public float jumpForce = 4f;
    public ParticleSystem JumpParicles;

    [Space]
    public ParticleSystem explosionParticles;
    public GameObject explosionLight;
    public ExplosionData explosionData;
    private bool isExploding = false;
    private float explosionTimer = 0f;

    [Space]
    public ParticleSystem shootParticles;
    public ShootData shootData;
    public bool isShooting = false;
    public float shootingTimer = 0f;

    [Space]
    public Button JumpButton;

    private Vector3 direction;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float delta = Time.deltaTime;

        if (explosionTimer > 0f)
        {
            explosionTimer -= delta;
            if(explosionTimer <= 0f)
            {
                SetExplosionObjects(false);
            }
        }

        if (isShooting)
        {
            shootingTimer -= delta;
            if (shootingTimer <= 0f)
            {
                isShooting = false;
            }
        }

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 0.55f);

        JumpButton.interactable = isGrounded;

        float horizontalInput = joystick.Horizontal;
        float verticalInput = 0f;

        if (isGrounded)
        {
            verticalInput = joystick.Vertical;
        }

        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if(direction.magnitude < 0.1f)
        {
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, new Vector3(0f, rigidbody.velocity.y, 0f), delta * 4f);
        }
        else if (rigidbody.velocity.magnitude <= maxSpeed)
        {
            rigidbody.AddForce(direction * accelerationSpeed, ForceMode.Acceleration);           
        }
        else
        {
            rigidbody.AddForce(direction * maxSpeed, ForceMode.Force);
        }
    }

    public void Explode()
    {
        if (!isExploding)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            aSource.PlayOneShot(explodeSound);
            SetExplosionObjects(true);
            explosionParticles.Play();
            explosionTimer = explosionData.explosionTimeout;
        }
    }

    private void SetExplosionObjects(bool isActive)
    {
        isExploding = isActive;
        explosion.transform.localScale *= explosionData.explosionRadius;
        explosion.SetActive(isActive);
        explosionLight.SetActive(isActive);
    }

    public void Shoot()
    {
        if (!isShooting)
        {            
            isShooting = true;
            aSource.PlayOneShot(shootSound);
            shootingTimer = shootData.shootTimeout;
            if(direction.magnitude > 0)
            {
                rigidbody.AddForce(Vector3.forward * shootData.shootForce + direction, ForceMode.Impulse);
            }

            shootParticles.transform.position = transform.position;
            shootParticles.Play();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            aSource.PlayOneShot(jumpSound);
            JumpParicles.transform.position = transform.position;
            JumpParicles.Play();
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
