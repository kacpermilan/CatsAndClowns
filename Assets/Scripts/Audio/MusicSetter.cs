using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetter : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.IsMusicPlaying = false;
    }
}
