using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private AudioSource aSource;
    public GameObject explosionRadius;

    [Space]
    public AudioClip shootSound;
    public AudioClip explodeSound;

    [Space]
    public ParticleSystem explosionParticles;
    public GameObject explosionLight;
    public ExplosionData explosionData;
    private bool isExploding = false;
    private float explosionTimer = 0f;

    [Space]
    public ParticleSystem shootParticles;
    public ShootData shootData;
    private bool isShooting = false;
    private float shootingTimer = 0f;

    private PlayerMovement movementController;
    private Rigidbody rigid;


    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        movementController = GetComponent<PlayerMovement>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float delta = Time.deltaTime;

        if (explosionTimer > 0f)
        {
            explosionTimer -= delta;
            if(explosionData.explosionTimeout - explosionTimer >= 0.5f)
            {
                SetExplosionObjects(false);
            }

            if(explosionTimer <= 0f)
            {
                isExploding = false;
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
    }

    public void Explode()
    {
        if (!isExploding)
        {
            rigid.AddForce(Vector3.up * (explosionData.explosionForce / 20f), ForceMode.Impulse);
            aSource.PlayOneShot(explodeSound);
            SetExplosionObjects(true);
            explosionParticles.Play();
            explosionTimer = explosionData.explosionTimeout;
            isExploding = true;
        }
    }

    private void SetExplosionObjects(bool isActive)
    {        
        explosionRadius.transform.localScale = Vector3.one * explosionData.explosionRadius;
        explosionRadius.SetActive(isActive);
        explosionLight.SetActive(isActive);
    }

    public void Shoot()
    {
        if (!isShooting)
        {            
            isShooting = true;
            aSource.PlayOneShot(shootSound);
            shootingTimer = shootData.shootTimeout;

            rigid.AddForce(Vector3.forward * shootData.shootForce + movementController.direction, ForceMode.Impulse);

            shootParticles.transform.position = transform.position;
            shootParticles.Play();
        }
    }
}
