using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject Backround_PauseMenu;
    public bool isPause;
    private AudioSource[] allAudioSources;

    private void Start()
    {
        pauseMenu.SetActive(false);
        Backround_PauseMenu.SetActive(false);
        isPause = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == false)
                pause();
            else 
                resume();
        }
    }
    public void pause()
    {
        pauseMenu.SetActive(true);
        Backround_PauseMenu.SetActive(true);
        isPause = true;
        StopAllAudio();
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Backround_PauseMenu.SetActive(false);
        isPause = false;
        Time.timeScale = 1f;
        ResumeAllAudio();

    }
    public void quit()
    {
        Application.Quit();

    }
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Pause();
        }
    }

    void ResumeAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.UnPause();
        }
    }
}
