using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/// <summary>
/// Class for using options in OptionsUI
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioManager audioManager;
    public Toggle toggle;
    public float mainVolume, sfxVolume, musicVolume;
    public bool motionBlurOn;
    /// <summary>
    /// Methods to allow user to change volumes with sliders
    /// </summary>
    /// <param value to pass into audio mixer="volume"></param>
    
    public void OptionsLoad()
    {
        SaveSystem.LoadOptions(this);
    }
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
    public void EnableMotionBlur()
    {
        if(motionBlurOn == false)
        {
            toggle.isOn = true;
            motionBlurOn = true;
        }
        else
        {
            toggle.isOn = false;
            motionBlurOn = false;
        }
    }
    public void OnClose()
    {
        SaveSystem.SaveAudio(mainVolume, sfxVolume, musicVolume);
        SaveSystem.SaveOptions(motionBlurOn,toggle.isOn);
    }
}
