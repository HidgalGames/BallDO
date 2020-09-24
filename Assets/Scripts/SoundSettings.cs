using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public AudioMixerGroup mixer;
    public bool soundEnabled = true;
    public bool musicEnabled = true;

    private void Start()
    {
        UpdateMusicValue();
        UpdateSoundValue();
    }

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
