using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private SoundSettings soundSettings;
    public Toggle soundToggle;
    public Toggle musicToggle;

    private void Start()
    {
        soundSettings = FindObjectOfType<SoundSettings>();
        soundToggle.isOn = !soundSettings.soundEnabled;
        musicToggle.isOn = !soundSettings.musicEnabled;
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
