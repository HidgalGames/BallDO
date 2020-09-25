using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Sound Settings")]
public class SoundSettings : ScriptableObject
{
    public AudioMixerGroup mixer;
    public bool soundEnabled = true;
    public bool musicEnabled = true;

    public void ToggleMusic(bool enabled)
    {
        musicEnabled = enabled;
        UpdateMusicValue();
    }

    public void ToggleSound(bool enabled)
    {
        soundEnabled = enabled;
        UpdateSoundValue();
    }

    public void UpdateValues()
    {
        UpdateMusicValue();
        UpdateSoundValue();
    }

    private void UpdateMusicValue()
    {
        if (musicEnabled)
        {
            mixer.audioMixer.SetFloat("MusicVolume", 0f);
        }
        else
        {
            mixer.audioMixer.SetFloat("MusicVolume", -80f);
        }
    }

    private void UpdateSoundValue()
    {
        if (soundEnabled)
        {
            mixer.audioMixer.SetFloat("SoundVolume", 0f);
        }
        else
        {
            mixer.audioMixer.SetFloat("SoundVolume", -80f);
        }
    }
}
