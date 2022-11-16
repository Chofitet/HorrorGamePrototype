using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    SoundDoor,
}

public class SoundManager : MonoBehaviour
{
    public void PlaySoud(AudioSource clip)
    {
        clip.Play();
    }
}
