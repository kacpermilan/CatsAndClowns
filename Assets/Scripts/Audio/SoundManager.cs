using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private Sound[] _sounds;

    private bool _isMusicPlaying;
    public bool IsMusicPlaying { get { return _isMusicPlaying; } set {  _isMusicPlaying = value; } }
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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && !_isMusicPlaying) {
            PlayExclusive("MainMenuSong");
            _isMusicPlaying = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1 && !_isMusicPlaying)
        {
            PlayExclusive("Introduction");
            _isMusicPlaying= true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2 && !_isMusicPlaying)
        {
            PlayExclusive("SamaGra");
            _isMusicPlaying= true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 && !_isMusicPlaying)
        {
            PlayExclusive("WinScreenMusic");
            _isMusicPlaying= true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4 && !_isMusicPlaying)
        {
            PlayExclusive("GameOverMusic");
            _isMusicPlaying= true;
        }
    }

    private void PlayExclusive(string name)
    {
        foreach (Sound sound in _sounds)
        {
            if (sound.GetName() == name)
            {
                sound.GetAudioSource().Play();
            }
            else
            {
                sound.GetAudioSource().Stop();
            }
        }
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

    private void Stop(string name)
    {
        foreach (Sound sound in _sounds)
        {
            if (sound.GetName() == name)
            {
                sound.GetAudioSource().Stop();
            }
        }
    }
}
