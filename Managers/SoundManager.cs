using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;

    public void MusicRelay(bool MusicRelayStatus)
    {
        Music.enabled = MusicRelayStatus;
    }

    public void MusicVolume(float value)
    {
        AudioListener.volume = value;
    }
}
