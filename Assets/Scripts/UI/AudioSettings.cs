using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void SetMasterAudio(float volume)
    {
        _audioMixer.SetFloat("Master", volume);
    }

    public void SetVFXAudio(float volume)
    {
        _audioMixer.SetFloat("VFX", volume);
    }

    public void SetMusicAudio(float volume)
    {
        _audioMixer.SetFloat("Music", volume);
    }
}
