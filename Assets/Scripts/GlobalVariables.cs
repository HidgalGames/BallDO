using UnityEngine;

#if UNITY_EDITOR
using System.IO;
using BasicTools.ButtonInspector;
#endif

[CreateAssetMenu(menuName = "Global Variables")]
public class GlobalVariables : ScriptableObject
{
#if UNITY_EDITOR
    [Button("Restore to Defaults", "RestoreToDefaults")]
    public bool restoreButton = false;
#endif

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

    [Header("Etc")]
    public bool firstStart = true;

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

        firstStart = data.firstStart;
    }

#if UNITY_EDITOR
    public void RestoreToDefaults()
    {
        string filePath = Application.persistentDataPath + "/data.bds";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

            playerCoins.TotalCoins = 0;
        playerDonatecoins.TotalCoins = 0;
        upgradeCoins.Value = 0;

        explData.RestoreToDefaults();
        shData.RestoreToDefaults();

        skins.RestoreSkins();

        lvlManager.RestoreLevelsToDefault();

        soundSettings.RestoreToDefaults();

        firstStart = true;

        Debug.Log("Restored to defaults");
    }
#endif
}
