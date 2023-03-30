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
    public AudioManager audioManager;
    public float mainVolume, sfxVolume, musicVolume;
    /// <summary>
    /// Methods to allow user to change volumes with sliders
    /// </summary>
    /// <param value to pass into audio mixer="volume"></param>

    public void ChangeVolume(float volume)
    {
        mainVolume = volume;
        audioMixer.SetFloat("Volume", mainVolume); ;
        
    }    
    
    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
        audioMixer.SetFloat("MusicVolume", musicVolume); ;
        
    }    
    
    public void ChangeSFXVolume(float volume)
    {
        sfxVolume = volume;
        audioMixer.SetFloat("SFXVolume", sfxVolume); ;
        
    }
    public void OnClose()
    {
        SaveSystem.SaveAudio(mainVolume, sfxVolume, musicVolume);
    }
}
