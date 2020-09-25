using UnityEngine;

[CreateAssetMenu(menuName = "Global Variables")]
public class GlobalVariables : ScriptableObject
{
    [Header("Coins")]
    public Coins playerCoins;
    public DonateCoins playerDonatecoins;
    public UpgradePointsObject upgradeCoins;

    [Header("Skills")]
    public ExplosionData explData;
    public ShootData shData;

    [Header("Skins")]
    public SkinsList skins;

    [Header("Levels")]
    public LevelsManager lvlManager;

    [Header("Sounds")]
    public SoundSettings soundSettings;

    public void LoadVariables(PlayerData data)
    {
        playerCoins.TotalCoins = data.coinsCount;
        playerDonatecoins.TotalCoins = data.donateCoinsCount;
        upgradeCoins.Value = data.upgradeCoinsCount;

        explData.explosionForceLevel = data.eForceLvl;
        explData.explosionForce = data.eForce;

        explData.explosionRadiusLevel = data.eRadiusLvl;
        explData.explosionRadius = data.eRadius;

        explData.explosionTimeoutLevel = data.eTimeoutLvl;
        explData.explosionTimeout = data.eTimeout;

        shData.shootForceLevel = data.sForceLvl;
        shData.shootForce = data.sForce;

        shData.shootTimeoutLevel = data.sTimeoutLvl;
        shData.shootTimeout = data.sTimeout;

        skins.currentSkin = data.currentSkin;
        for(int i = 0; i <= data.skinsLockStats.GetUpperBound(0); i++)
        {
            skins.playerSkins[i].locked = (data.skinsLockStats[i, 0] == 1);
        }

        lvlManager.currentLevel = data.currentLvl;
        for(int i = 0; i <= data.levelsStats.GetUpperBound(0); i++)
        {
            lvlManager.levels[i].rating = data.levelsStats[i, 0];
            lvlManager.levels[i].unlocked = (data.levelsStats[i, 1] == 0);
            lvlManager.levels[i].upgradeCoinsCount = data.levelsStats[i, 2];
        }

        soundSettings.soundEnabled = data.soundsEnabled;
        soundSettings.musicEnabled = data.musicEnabled;
    }
}
