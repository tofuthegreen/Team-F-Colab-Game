using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class for changing lighting in game
/// </summary>
public class LightsOut : MonoBehaviour
{
    [SerializeField]
    private float dark;
    [SerializeField]
    private float normal;
    [SerializeField]
    private float fogDark;
    [SerializeField]
    private float fogNormal;

    private float timer;
    private float lap = 10;

    //Method for triggering lights out after an amount of time and setting
    //a new random time
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > lap)
        {
            LightsOff();
            StartCoroutine(Duration());
            timer = -5;
            lap = Random.Range(10, 30);
        }
    }

    public IEnumerator Duration()
    {
        yield return new WaitForSeconds(5);

        LightsOn();
    }

    /// <summary>
    /// Methods for changing lighting settings
    /// </summary>
    public void LightsOff()
    {
        RenderSettings.ambientIntensity = dark;
        RenderSettings.fogDensity = fogDark;
    }    
    
    public void LightsOn()
    {
        RenderSettings.ambientIntensity = normal;
        RenderSettings.fogDensity = fogNormal;
    }
}
