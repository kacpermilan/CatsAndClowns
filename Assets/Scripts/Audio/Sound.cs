using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private string _name;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _volume;
    [SerializeField] private bool _isLooping;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    public AudioSource GetAudioSource() { return _audioSource; }
    public void SetAudioSource(AudioSource audioSource) {  _audioSource = audioSource; }

    public string GetName() { return _name; }

    public AudioClip GetClip() { return _clip; }
    public float GetVolume () { return _volume; }
    public bool IsLooping() { return _isLooping; }

    public AudioMixerGroup GetAudioMixerGroup() { return _audioMixerGroup; }

}
