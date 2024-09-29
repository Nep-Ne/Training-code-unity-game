using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject GameoverMenu;
    private void Start()
    {
        GameoverMenu.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();

    }

    public void restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void ActiveGameOver()
    {
        GameoverMenu.SetActive(true);
    }

}
