using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public ExplosionData explosionData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.attachedRigidbody.AddExplosionForce(explosionData.explosionForce, transform.position, 3f);
        }
    }
}
