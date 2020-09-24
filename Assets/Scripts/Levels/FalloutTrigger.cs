using UnityEngine;

public class FalloutTrigger : MonoBehaviour
{
    public Transform startPoint;
    public LevelPointsManager lvlPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = startPoint.position;
            lvlPoints.AddPoints(-1);
        }
        else if(other.CompareTag("Enemy"))
        {
            lvlPoints.AddPoints(other.GetComponent<Enemy>().pointsToAdd);
            other.gameObject.SetActive(false);
        }
    }
}
