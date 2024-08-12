using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPause;
    private void Start()
    {
        pauseMenu.SetActive(false);
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
        isPause = true;
        Time.timeScale = 0f;

    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        isPause = false;
        Time.timeScale = 1f;
    }
    public void quit()
    {
        Application.Quit();

    }
}
