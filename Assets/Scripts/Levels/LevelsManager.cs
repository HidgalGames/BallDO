using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu (menuName = "Levels Manager")]
public class LevelsManager : ScriptableObject
{
    public List<Level> levels;

    [Min(0)] public int currentLevel = 1;

    public void GoTutorial()
    {
        SceneManager.LoadSceneAsync(levels[0].sceneIndex);
    }

    public bool ChangeCurrentLevel(int levelIndex)
    {
        if (levelIndex < levels.Count)
        {
            if (levels[levelIndex].unlocked)
            {
                currentLevel = levelIndex;
                return true;
            }
        }

        return false;
    }

    public void GoToCurrentLevel()
    {
        SceneManager.LoadSceneAsync(levels[currentLevel].sceneIndex);
    }

    public void GoToNextLevel()
    {
        ChangeCurrentLevel(currentLevel + 1);
        GoToCurrentLevel();
    }

    public void GoToLevel(int levelIndex)
    {
        if (ChangeCurrentLevel(levelIndex))
        {
            GoToCurrentLevel();
        }
    }

    public void GetUpgradeCoinsFromCurrentLevel(int coinsCount)
    {
        levels[currentLevel].GetUpgradeCoins(coinsCount);
    }

    public void UnlockNextLevel()
    {
        if(currentLevel < levels.Count - 1)
        {
            levels[currentLevel + 1].unlocked = true;
        }
    }

    public void RateCurrentLevel(int rate)
    {
        levels[currentLevel].SetRating(rate);
    }

#if UNITY_EDITOR
    public void RestoreLevelsToDefault()
    {
        currentLevel = 1;

        foreach (Level lvl in levels)
        {
            lvl.RestoreToDefaults();
        }
    }
#endif
}
