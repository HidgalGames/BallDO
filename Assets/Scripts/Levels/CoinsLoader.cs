using UnityEngine;

public class CoinsLoader : MonoBehaviour
{
    public GameObject CoinPrefab;

    [Space]
    public LevelsManager lvlManager;
    private Level CurrentLevel;
    public Transform[] CoinPositions;

    private void Start()
    {
        CurrentLevel = lvlManager.levels[lvlManager.currentLevel];

        for(int i = 0; i < CurrentLevel.upgradeCoinsCount; i++)
        {
            Instantiate(CoinPrefab, CoinPositions[i]);
        }
    }
}
