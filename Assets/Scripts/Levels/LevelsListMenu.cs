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

    private float stringSize = 250f;
    private int rows = 3;

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
        int strings = Mathf.CeilToInt((float)(lvlManager.levels.Count) / (float) rows);
        RectTransform parentRect = parentObject.GetComponent<RectTransform>();
        parentRect.sizeDelta = new Vector2(parentRect.sizeDelta.x, stringSize * strings);

        int i = 0;
        for (; i < lvlManager.levels.Count; i++)
        {
            GameObject bgo = Instantiate(levelButtonPrefab, parentObject);
            LevelButton button = bgo.GetComponent<LevelButton>();
            button.SetupButton(i, lvlManager.levels[i].rating, lvlManager.levels[i].unlocked, lvlManager.levels[i].upgradeCoinsCount, lvlManager);
            buttons.Add(button);
        }

        if(i % rows == 0)
        {
            parentRect.sizeDelta = new Vector2(parentRect.sizeDelta.x, stringSize * (strings + 1));
        }

        GameObject bgob = Instantiate(levelButtonPrefab, parentObject);
        LevelButton buttonn = bgob.GetComponent<LevelButton>();
        buttonn.SetNewLevelsSoonButton();

    }
}
