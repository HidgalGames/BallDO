using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public SoundSettings soundSettings;
    public Toggle soundToggle;
    public Toggle musicToggle;

    [Space]
    public TextMeshProUGUI lvlNameText;
    public TextMeshProUGUI highscoreText;
    public LevelsManager lvlManager;

    private void Start()
    {
        soundToggle.isOn = !soundSettings.soundEnabled;
        musicToggle.isOn = !soundSettings.musicEnabled;
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

    public void ToggleMusic()
    {
        soundSettings.ToggleMusic(!musicToggle.isOn);
    }

    public void ToggleSound()
    {
        soundSettings.ToggleSound(!soundToggle.isOn);
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
