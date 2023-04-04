using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public float mainVolume, sfxVolume, musicVolume;
    public AudioMixer audioMixer;
    public Slider main, sfx, music;
    // Start is called before the first frame update
    private void Start()
    {
        AudioVariables();
    }
    public void AudioVariables()
    {
        SaveSystem.LoadAudio(this);
        audioMixer.SetFloat("Volume", mainVolume); ;
        audioMixer.SetFloat("MusicVolume", musicVolume); ;
        audioMixer.SetFloat("SFXVolume", sfxVolume); ;
        main.value = mainVolume;
        sfx.value = sfxVolume;
        music.value = musicVolume;
    }

    private void Awake()
    {
        
    }
}
