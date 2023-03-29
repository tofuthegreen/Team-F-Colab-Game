using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Class for using options in OptionsUI
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    /// <summary>
    /// Methods to allow user to change volumes with sliders
    /// </summary>
    /// <param value to pass into audio mixer="volume"></param>
    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume); ;
    }    
    
    public void ChangeMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume); ;
    }    
    
    public void ChangeSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume); ;
    }
}
