using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for pausing game and displaying UI to player
/// </summary>
public class PauseMenu : MonoBehaviour
{
    private bool gamePaused = false;

    [SerializeField] GameObject uiPause;

    void Update()
    {
        //Checks if game is paused and pauses or resumes when Esc is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Method to resume game by returning game time to normal
    /// </summary>
    public void Resume()
    {
        uiPause.SetActive(false);

        Time.timeScale = 1f;
        gamePaused = false;
    }

    /// <summary>
    /// Method to resume game by changing game time to 0 to 'pause' the game
    /// </summary>
    public void Pause()
    {
        uiPause.SetActive(true);

        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
