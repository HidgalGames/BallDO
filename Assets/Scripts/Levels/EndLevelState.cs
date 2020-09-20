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
    [SerializeField] private List<Enemy> affectedEnemies;
    private bool waitForEndAffect = false;
    private bool endLevelTriggered = false;

    private int rate = 0;

    private int upgradePointsToAdd = 0;

    private void FixedUpdate()
    {
        waitForEndAffect = affectedEnemies.Count > 0;

        if (!waitForEndAffect && endLevelTriggered)
        {
            endLevelTriggered = false;
            EndLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endLevelTriggered = true;
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

    private void EndLevel()
    {
        float percent = (float) lvlPoints.LevelPoints / (float) (enemiesCount * 10);

        if (percent >= 0.8f)
        {
            rate = 5;
        }
        else if (percent >= 0.5f)
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

        lvlManager.RateCurrentLevel(rate);
        EndLvlMenu.DrawRating(rate);
        upgradePoints.Add(upgradePointsToAdd);

        if (rate > 0)
        {
            soundManager.PlayLevelCompleted();
            lvlManager.UnlockNextLevel();
            EndLvlMenu.completeText.text = "LEVEL COMPLETED!";
        }
        else
        {
            EndLvlMenu.completeText.text = "LEVEL FAILED :(";
            soundManager.PlayLevelFailed();
        }

        UIController.GoToEndLevelMenu(rate > 0);
    }
}
