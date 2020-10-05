using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelState : MonoBehaviour
{
    public SoundManager soundManager;

    [Space]
    public UpgradePointsObject upgradePoints;

    [Space]
    public UIFunctions UIController;
    public EndLevelMenu EndLvlMenu;
    public LevelsManager lvlManager;
    public LevelPointsManager lvlPoints;
    public int enemiesCount = 0;

    [Space]
    public int coinsForEachStar = 50;

    [Space]
    public ParticleSystem[] endLevelPatricles;

    [Space]
    [SerializeField] private List<Enemy> affectedEnemies;
    private bool waitForEndAffect = false;
    private bool endLevelTriggered = false;

    public Coins playerCoins;

    private int rate = 0;

    private int upgradePointsToAdd = 0;

    private void FixedUpdate()
    {
        waitForEndAffect = affectedEnemies.Count > 0;

        if (!waitForEndAffect && endLevelTriggered)
        {
            endLevelTriggered = false;
            StartCoroutine(EndLevel());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endLevelTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endLevelTriggered = false;
        }
    }

    public bool AddAffectedEnemy(Enemy enemy)
    {        
        if (!affectedEnemies.Contains(enemy))
        {
            affectedEnemies.Add(enemy);
            return true;
        }

        return false;
    }

    public bool RemoveAffectedEnemy(Enemy enemy)
    {
        if (affectedEnemies.Contains(enemy))
        {
            affectedEnemies.Remove(enemy);
            return true;
        }

        return false;
    }

    public void AddUpgradePoints(int points)
    {
        upgradePointsToAdd += points;
    }

    IEnumerator EndLevel()
    {
        foreach(ParticleSystem p in endLevelPatricles)
        {
            p.Play();
        }
        yield return new WaitForSeconds(0.4f);

        float percent = (float) lvlPoints.LevelPoints / (float) (enemiesCount * 10);

        if (percent >= 0.85f)
        {
            rate = 5;
        }
        else if (percent >= 0.6f)
        {
            rate = 4;
        }
        else if (percent >= 0.3f)
        {
            rate = 3;
        }
        else if (percent >= 0.2f)
        {
            rate = 2;
        }
        else if (percent >= 0.1f)
        {
            rate = 1;
        }
        else
        {
            rate = 0;
        }

        int delta = rate - lvlManager.levels[lvlManager.currentLevel].rating;

        lvlManager.RateCurrentLevel(rate);
        EndLvlMenu.SetRating(rate);

        if (rate > 0)
        {
            lvlManager.GetUpgradeCoinsFromCurrentLevel(upgradePointsToAdd);
            upgradePoints.Add(upgradePointsToAdd);
            soundManager.PlayLevelCompleted();
            lvlManager.UnlockNextLevel();
            EndLvlMenu.completeText.text = "LEVEL COMPLETED!";

            if (delta >= 0)
            {
                playerCoins.AddCoins(delta * coinsForEachStar);
                EndLvlMenu.SetCoins(delta * coinsForEachStar);
            }
        }
        else
        {
            EndLvlMenu.completeText.text = "LEVEL FAILED :(";
            soundManager.PlayLevelFailed();
        }

        UIController.GoToEndLevelMenu(rate > 0);

        yield return null;
    }
}
