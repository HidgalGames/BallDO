using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource source;
    public List<AudioClip> buttonSounds;
    public AudioClip lvlCompleteSound;
    public AudioClip lvlFailedSound;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        source.PlayOneShot(buttonSounds[Random.Range(0, buttonSounds.Count - 1)]);
    }

    public void PlayLevelCompleted()
    {
        source.PlayOneShot(lvlCompleteSound);
    }

    public void PlayLevelFailed()
    {
        source.PlayOneShot(lvlFailedSound);
    }
}
