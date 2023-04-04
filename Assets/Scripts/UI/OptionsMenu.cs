using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.VFX;
/// <summary>
/// Class for using options in OptionsUI
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioManager audioManager;
    public Toggle toggle;
    public Camera mainCamera;
    public float mainVolume, sfxVolume, musicVolume;
    public bool motionBlurOn;

    public int AAmode;
    public TMP_Dropdown dropDown;
    public MotionBlur motionBlur;
    public VolumeProfile playerProfile;
    public Volume playerVolume;
    /// <summary>
    /// Methods to allow user to change volumes with sliders
    /// </summary>
    /// <param value to pass into audio mixer="volume"></param>
    private void Start()
    {
        playerProfile.TryGet<MotionBlur>(out MotionBlur tmp);
        motionBlur = tmp;
        dropDown.value = AAmode;
        toggle.SetIsOnWithoutNotify(motionBlurOn);
        motionBlur.active = motionBlurOn;
    }

    public void OptionsLoad()
    {
        SaveSystem.LoadOptions(this);
    }

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

    /// <summary>
    /// Method to change music track in game scene
    /// </summary>
    public void ChangeMusic(int musicTrack)
    {
        audioManager.currentMusicTrack = musicTrack;
    }
    public void ChangeMotionBlur(bool onValueChanged)

    {
        if(onValueChanged == false)
        {
            motionBlurOn = false;
            motionBlur.active = false;
            toggle.SetIsOnWithoutNotify(motionBlurOn);
        }
        else
        {
            motionBlurOn = true;
            motionBlur.active = true;
            toggle.SetIsOnWithoutNotify(motionBlurOn);
        }

    }
    public void ChangeAA(int val) 
    {
        AAmode = val;
        switch (val)
        {
            case 0:
                Camera.main.GetComponent<UniversalAdditionalCameraData>().antialiasing = AntialiasingMode.None;
                break;
            case 1:
                Camera.main.GetComponent<UniversalAdditionalCameraData>().antialiasing = AntialiasingMode.FastApproximateAntialiasing;
                Camera.main.GetComponent<UniversalAdditionalCameraData>().antialiasingQuality = AntialiasingQuality.High;
                break;
            case 2:
                Camera.main.GetComponent<UniversalAdditionalCameraData>().antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                Camera.main.GetComponent<UniversalAdditionalCameraData>().antialiasingQuality = AntialiasingQuality.High;
                break;
        }

    }
    public void OnClose()
    {
        SaveSystem.SaveAudio(mainVolume, sfxVolume, musicVolume);
        SaveSystem.SaveData(audioManager.currentMusicTrack, "currentTrack");

        SaveSystem.SaveOptions(motionBlurOn,AAmode);

    }
}
