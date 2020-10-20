using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenu;
    public AudioMgr audioMgr;
    public Slider loudslider;
    public GameObject unmute;
    public GameObject mute;

    private void Start()
    {
        loudslider.value = PlayerPrefs.GetFloat("volume");
        audioMgr.UpdVolume();
        UpdMuter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Muter()
    {
        var m = PlayerPrefs.GetInt("mute");
        if (m == 1)
            PlayerPrefs.SetInt("mute", 0);
        else
            PlayerPrefs.SetInt("mute", 1);
        UpdMuter();
        audioMgr.UpdVolume();
    }

    public void UpdMuter()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
        {
            unmute.SetActive(false);
            mute.SetActive(true);
        }
        else
        {
            unmute.SetActive(true);
            mute.SetActive(false);
        }
    }

    public void VolChanged()
    {
        audioMgr.SetVolume(loudslider.value);
    }
}
