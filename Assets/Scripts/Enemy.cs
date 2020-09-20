using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pointsToAdd = 10;

    [Space]
    public AudioClip hitSound;
    private AudioSource source;

    private EndLevelState endlvl;
    private Rigidbody rigid;
    private bool affected = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        endlvl = Transform.FindObjectOfType<EndLevelState>();
    }

    private void FixedUpdate()
    {
        if (affected)
        {
            if (Mathf.Approximately(rigid.velocity.magnitude, 0f))
            {
                endlvl.RemoveAffectedEnemy(this);
                affected = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(hitSound);

        if (collision.gameObject.CompareTag("Player"))
        {
            endlvl.AddAffectedEnemy(this);
            affected = true;
        }
    }

    private void OnDisable()
    {
        endlvl.RemoveAffectedEnemy(this);
    }
}
