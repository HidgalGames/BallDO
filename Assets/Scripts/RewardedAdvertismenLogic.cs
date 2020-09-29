using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using TMPro;

public class RewardedAdvertismenLogic : MonoBehaviour, IUnityAdsListener
{
    public Coins playerCoins;
    public Button adsButton;
    public string gameID = "3830149";
    public string myPlacementId = "rewardedVideo";
    public bool testMode = false;
    public int coinsToAdd = 200;
    public TextMeshProUGUI coinsTooltip;

    private void Start()
    {
        adsButton.interactable = false;
        coinsTooltip.text = coinsToAdd.ToString();
        
        if (Advertisement.isSupported)
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameID, testMode);
        }        
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            adsButton.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ads error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            playerCoins.AddCoins(coinsToAdd);
        }
        else if (showResult == ShowResult.Skipped)
        {
            return;
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }
}
