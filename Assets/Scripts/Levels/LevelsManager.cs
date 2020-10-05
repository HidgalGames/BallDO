using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu (menuName = "Levels Manager")]
public class LevelsManager : ScriptableObject
{
    public FallsCount fc;

    [Space]
    public List<Level> levels;

    [Min(0)] public int currentLevel = 0;

    public void GoTutorial()
    {
        fc.Set(0);
        SceneManager.LoadSceneAsync(levels[0].sceneIndex);
    }

    public void TutorialDenied()
    {
        ChangeCurrentLevel(1);
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
        fc.Set(0);
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
        currentLevel = 0;

        foreach (Level lvl in levels)
        {
            lvl.RestoreToDefaults();
        }
    }
#endif
}
