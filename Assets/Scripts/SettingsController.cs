using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("starttest");
        SceneManager.LoadScene("FirstLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
