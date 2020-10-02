using UnityEngine;

[CreateAssetMenu(menuName = "New Level")]
public class Level : ScriptableObject
{
    [Range(0, 5)]
    public int rating = 0;
    public string sceneIndex;
    public bool unlocked = false;
    [Min(0)] public int upgradeCoinsCount = 0;

#if UNITY_EDITOR
    [Header("Defaults")]
    [Min(0)] public int defaultCoinsCount = 0;
    public bool defaultUnlockState = false;

    public void RestoreToDefaults()
    {
        rating = 0;
        unlocked = defaultUnlockState;
        upgradeCoinsCount = defaultCoinsCount;
    }
#endif

    public void SetRating(int rate)
    {
        if(rate > rating)
        {
            rating = rate;
        }
    }

    public void GetUpgradeCoins(int coinsCount)
    {
        upgradeCoinsCount-= coinsCount;
    }

    public void Unlock()
    {
        unlocked = true;
    }
}
