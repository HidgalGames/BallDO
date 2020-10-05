using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public Tutorial tutorialFunctions;
    public Transform startPoint;
    public int triggerNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorialFunctions.ShowScreen(triggerNumber);
            startPoint.position = transform.position;
        }
    }
}
