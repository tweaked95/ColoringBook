using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public SceneController sceneController;
    public PlayerController playerController;

    GameObject colorPicker;
    GameObject settings;
    GameObject endGameScreen;
    void Start()
    {
        colorPicker = transform.GetChild(0).gameObject;
        settings = transform.GetChild(1).gameObject;
        endGameScreen = transform.GetChild(2).gameObject;
        colorPicker.SetActive(false);
        settings.SetActive(false);
    }

    public void OpenColorPicker()
    {
        colorPicker.SetActive(true);
    }

    public void SetColor(string color)
    {
        sceneController.SetCurrentColor(color);
        colorPicker.SetActive(false);
    }

    public void ShowButton(string color)
    {
        if (color == "red")
        {
            transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            sceneController.AddRed();
        }
        if (color == "blue")
        {
            transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            sceneController.AddBlue();
        }
        if (color == "green")
        {
            transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            sceneController.AddGreen();
        }
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
        playerController.DoSlowMo();
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
        playerController.NormalTime();
    }

    public void EndGame()
    {
        endGameScreen.SetActive(true);
    }
}
