using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu (menuName = "Levels Manager")]
public class LevelsManager : ScriptableObject
{
    public List<Level> levels;

    [Min(0)] public int currentLevel = 0;

    public void RaiseCurrentLevelNumber()
    {
        if(currentLevel < levels.Count - 1)
        {
            if (levels[currentLevel + 1].unlocked && levels[currentLevel].rating > 0)
            {
                currentLevel++;
            }
        }

    }

    public void ChangeCurrentLevel(int levelNumber)
    {
        currentLevel = levelNumber;
    }

    public void GoToCurrentLevel()
    {
        SceneManager.LoadSceneAsync(levels[currentLevel].sceneIndex);
    }

    public void GoToNextLevel()
    {
        if(currentLevel + 1 < levels.Count - 1)
        {
            currentLevel++;
            GoToCurrentLevel();
        }
    }

    public void GoToLevel(int levelIndex)
    {
        if(levels.Count > levelIndex)
        {
            if (levels[levelIndex].unlocked)
            {
                currentLevel = levelIndex;
                GoToCurrentLevel();
            }
        }
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
}
