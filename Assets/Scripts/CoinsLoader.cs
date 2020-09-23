using UnityEngine;

public class CoinsLoader : MonoBehaviour
{
    public GameObject CoinPrefab;
    
    [Space]
    public Level CurrentLevel;
    public Transform[] CoinPositions;

    private void Start()
    {
        for(int i = 0; i < CurrentLevel.upgradeCoinsCount; i++)
        {
            Instantiate(CoinPrefab, CoinPositions[i]);
        }
    }
}
