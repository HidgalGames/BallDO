using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
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
}
