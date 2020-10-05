using System.Collections.Generic;
using UnityEngine;

public class LevelsListMenu : MonoBehaviour
{
    [SerializeField] private LevelsManager lvlManager;
    public GameObject levelButtonPrefab;

    [Space]
    public Transform parentObject;

    [Space]
    public List<LevelButton> buttons = new List<LevelButton>();

    private void Start()
    {
        FillMenuList();
    }

    public void UnlockButton(int levelIndex)
    {
        buttons[levelIndex].UnlockButton();
    }

    private void FillMenuList()
    {
        int rows = 3;
        int strings = Mathf.CeilToInt((float)(lvlManager.levels.Count - 1) / (float) rows);

        RectTransform parentRect = parentObject.GetComponent<RectTransform>();
        parentRect.sizeDelta = new Vector2(parentRect.sizeDelta.x, 250 * strings);

        for(int i = 0; i < strings; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                if(i * rows + j + 1 >= lvlManager.levels.Count)
                {
                    return;
                }

                GameObject bgo = Instantiate(levelButtonPrefab, parentObject);
                LevelButton button = bgo.GetComponent<LevelButton>();
                button.SetupButton(i * rows + j + 1, lvlManager.levels[i * rows + j + 1].rating, lvlManager.levels[i * rows + j + 1].unlocked, lvlManager.levels[i * rows + j + 1].upgradeCoinsCount, lvlManager);
                buttons.Add(button);
            }
        }
    }
}
