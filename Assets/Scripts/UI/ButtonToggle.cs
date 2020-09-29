using UnityEngine;
using UnityEngine.UI;

public enum ToggleType
{
    Sound,
    Music
}

public class ButtonToggle : MonoBehaviour
{
    public SoundSettings settings;
    public ToggleType toggleType;
    public GameObject deactivatedImage;

    public bool isActive = true;

    private void Start()
    {
        switch (toggleType)
        {
            case ToggleType.Sound:
                isActive = settings.soundEnabled;
                break;

            case ToggleType.Music:
                isActive = settings.musicEnabled;
                break;
        }

        deactivatedImage.SetActive(!isActive);
    }

    public void Toggle()
    {
        isActive = !isActive;

        switch (toggleType)
        {
            case ToggleType.Sound:
                settings.ToggleSound(isActive);
                break;

            case ToggleType.Music:
                settings.ToggleMusic(isActive);
                break;
        }

        deactivatedImage.SetActive(!isActive);
    }
}
