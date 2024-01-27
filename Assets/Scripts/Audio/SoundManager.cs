using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private Sound[] _sounds;

    private void Start()
    {
        for (int i = 0; i < _sounds.Length; i++)
        {
            _sounds[i].SetAudioSource(gameObject.AddComponent<AudioSource>());
            _sounds[i].GetAudioSource().clip = _sounds[i].GetClip();
            _sounds[i].GetAudioSource().volume = _sounds[i].GetVolume();
            _sounds[i].GetAudioSource().loop = _sounds[i].IsLooping();
            _sounds[i].GetAudioSource().outputAudioMixerGroup = _sounds[i].GetAudioMixerGroup();
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    //We subscribe to events which get triggered, when particular sound is to play.
    // On this subscription we call Play and pass name which corresponds to name on Sound class
    private void Play(string name)
    {
        foreach (Sound sound in _sounds)
        {
            if (sound.GetName() == name)
            {
                sound.GetAudioSource().Play();
            }
        }
    }
}
