using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class FalloutTrigger : MonoBehaviour, IUnityAdsListener
{
    public GlobalVariables globalVars;
    public Transform startPoint;
    public bool tutorial = false;
    public LevelPointsManager lvlPoints;

    [Space]
    private string gameID;
    private string myPlacementId = "video";
    public FallsCount fc;

    private void Start()
    {
        gameID = globalVars.gameID;

        if (Advertisement.isSupported)
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameID, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!tutorial)
            {

                fc.Add();
                /*
                if(fc.Get() == 3)
                {
                    fc.Set(0);
                    if (Advertisement.IsReady(myPlacementId))
                    {
                        Advertisement.Show(myPlacementId);
                    }
                    else
                    {
                        Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
                    }
                }
                */

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);                
            }
            else
            {
                other.transform.position = startPoint.position;
            }
        }
        else if(other.CompareTag("Enemy"))
        {
            lvlPoints.AddPoints(other.GetComponent<Enemy>().pointsToAdd);
            other.gameObject.SetActive(false);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        return;
    }

    public void OnUnityAdsDidError(string message)
    {
        return;
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        return;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        return;
    }
}
