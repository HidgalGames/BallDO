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
        int rows = Mathf.FloorToInt(Screen.width / 320);
        int strings = Mathf.CeilToInt(lvlManager.levels.Count / rows);

        if(strings == 0)
        {
            strings = 1;
        }

        for(int i = 0; i < strings; i++)
        {
            for(int j = 1; j <= rows; j++)
            {
                if(i + j >= lvlManager.levels.Count)
                {
                    return;
                }

                GameObject bgo = Instantiate(levelButtonPrefab, this.transform);
                LevelButton button = bgo.GetComponent<LevelButton>();
                RectTransform buttonTransform = button.gameObject.GetComponent<RectTransform>();
                buttonTransform.anchoredPosition += new Vector2(256 * (j - 1), -256 * i);
                button.SetupButton(i + j, lvlManager.levels[i + j].rating, lvlManager.levels[i + j].unlocked, lvlManager.levels[i + j].upgradeCoinsCount, lvlManager);
                buttons.Add(button);
            }
        }
    }
}
