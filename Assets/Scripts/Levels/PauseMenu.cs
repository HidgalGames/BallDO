using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public SoundSettings soundSettings;

    [Space]
    public TextMeshProUGUI lvlNameText;
    public TextMeshProUGUI highscoreText;
    public LevelsManager lvlManager;

    private void Start()
    {
        if(lvlManager.currentLevel > 0)
        {
            lvlNameText.text = "LVL " + lvlManager.currentLevel.ToString();
            highscoreText.text = "HIGHSCORE: " + lvlManager.levels[lvlManager.currentLevel].rating;
        }
        else
        {
            lvlNameText.text = "TUTORIAL";
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
