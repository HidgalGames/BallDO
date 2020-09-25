using UnityEngine;

public class UpgradeCoin : MonoBehaviour
{
    public int AddPoints = 1;
    private EndLevelState endLevel;

    [Space]
    public AudioClip coinSound;
    private AudioSource source;

    [Space]
    public ParticleSystem particles;

    private bool triggered = false;

    private void Start()
    {
        endLevel = Transform.FindObjectOfType<EndLevelState>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (triggered)
        {
            if(!source.isPlaying)
            {
                triggered = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(coinSound);
            particles.Play();
            endLevel.AddUpgradePoints(AddPoints);
            triggered = true;
        }
    }
}
