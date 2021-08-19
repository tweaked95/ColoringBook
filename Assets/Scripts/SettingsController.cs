using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public void ResumeGame()
    {
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("IntroLevel_01");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
