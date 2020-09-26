using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button currentButton;
    private SoundManager sManager;

    [Space]
    public Image additiveImage;
    public Color unlockedColorAdditive;
    public Color lockedColorAdditive;

    [Space]
    public int levelNubmber = 0;
    public int levelRating = 0;
    public bool isUnlocked = false;
    public TextMeshProUGUI buttonName;
    public TextMeshProUGUI lvlRatingText;
    private LevelsManager lvlManager;

    private void Start()
    {
        currentButton = gameObject.GetComponent<Button>();
        sManager = Camera.main.gameObject.GetComponent<SoundManager>();
    }

    public void SetupButton(int lvlNumber, int lvlRating, bool unlocked, LevelsManager lvlMng)
    {
        SetupLvlManager(lvlMng);
        levelNubmber = lvlNumber;
        levelRating = lvlRating;
        isUnlocked = unlocked;

        if (isUnlocked)
        {
            UnlockButton();
        }

        buttonName.text = "LVL " + lvlNumber.ToString();
        lvlRatingText.text = string.Empty;
        DrawRating();
    }

    public void ChangeRating(int rating)
    {
        levelRating = rating;
        DrawRating();
    }

    public void UnlockButton()
    {
        isUnlocked = true;
        currentButton.interactable = isUnlocked;
        additiveImage.color = unlockedColorAdditive;
    }

    public void SetupLvlManager(LevelsManager mng)
    {
        lvlManager = mng;
    }

    public void GoToButtonLevel()
    {
        sManager.PlayButtonSound();
        lvlManager.GoToLevel(levelNubmber);
    }

    private void DrawRating()
    {
        for (int i = 0; i < levelRating; i++)
        {
            lvlRatingText.text += "* ";
        }
    }
}
