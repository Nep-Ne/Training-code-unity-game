using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Application.Quit();

    }
    public void Back(GameObject thisGameObject)
    {
        thisGameObject.SetActive(false);
    }

    public void OpenTutorial(GameObject tutorialObject)
    {
        tutorialObject.SetActive(true);
    }
}
