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
        SceneManager.LoadScene("FirstLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
