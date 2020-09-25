using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [Header("Coins")]
    public int coinsCount;
    public int donateCoinsCount;
    public int upgradeCoinsCount;

    [Header("Explosion SKill")]
    public int eRadiusLvl;
    public float eRadius;
    [Space]
    public int eForceLvl;
    public float eForce;
    [Space]
    public int eTimeoutLvl;
    public float eTimeout;

    [Header("Shoot Skill")]
    public int sForceLvl;
    public float sForce;
    [Space]
    public int sTimeoutLvl;
    public float sTimeout;

    [Header("Skins")]
    public int currentSkin;
    public int[,] skinsLockStats; // [номер скина, статус (1 - заблокирован, 0 - разблокирован)]

    [Header("Levels")]
    public int currentLvl;
    public int[,] levelsStats; //[номер уровня, рейтинг, статус (1 - заблокирован, 0 - разблокирован), кол-во upgrade coins]

    [Header("Sounds")]
    public bool soundsEnabled;
    public bool musicEnabled;

    [Header("Etc")]
    public bool firstStart = true;

    public PlayerData(GlobalVariables variables)
    {
        coinsCount = variables.playerCoins.TotalCoins;
        donateCoinsCount = variables.playerDonatecoins.TotalCoins;
        upgradeCoinsCount = variables.upgradeCoins.Value;

        eRadiusLvl = variables.explData.explosionRadiusLevel;
        eRadius = variables.explData.explosionRadius;

        eForceLvl = variables.explData.explosionForceLevel;
        eForce = variables.explData.explosionForce;

        eTimeoutLvl = variables.explData.explosionTimeoutLevel;
        eTimeout = variables.explData.explosionTimeout;

        sForceLvl = variables.shData.shootForceLevel;
        sForce = variables.shData.shootForce;

        sTimeoutLvl = variables.shData.shootTimeoutLevel;
        sTimeout = variables.shData.shootTimeout;

        currentSkin = variables.skins.currentSkin;
        Skin[] skins = variables.skins.playerSkins;
        skinsLockStats = new int[skins.Length, 1];
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].locked)
            {
                skinsLockStats[i, 0] = 1;
            }
            else
            {
                skinsLockStats[i, 0] = 0;
            }         
        }

        currentLvl = variables.lvlManager.currentLevel;
        List<Level> levels = variables.lvlManager.levels;
        //[номер уровня, [рейтинг, статус (1 - заблокирован, 0 - разблокирован), кол-во upgrade coins]]
        levelsStats = new int[levels.Count, 3];
        for (int i = 0; i < levels.Count; i++)
        {
            levelsStats[i, 0] = levels[i].rating;

            if (levels[i].unlocked)
            {
                levelsStats[i, 1] = 0;
            }
            else
            {
                levelsStats[i, 1] = 1;
            }

            levelsStats[i, 2] = levels[i].upgradeCoinsCount;            
        }

        soundsEnabled = variables.soundSettings.soundEnabled;
        musicEnabled = variables.soundSettings.musicEnabled;

        firstStart = variables.firstStart;
    }
}
