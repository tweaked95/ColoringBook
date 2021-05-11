using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SceneController : MonoBehaviour
{
    [SerializeField] string currentColor;

    public RigidBodyController rbControl;
    public PlayerController playerController;
    public Volume volume;

    ColorCurves colorCurves;
    void Start()
    {
        currentColor = "default";
        if (volume.profile.TryGet(out colorCurves))
        {
            colorCurves.hueVsSat.value.AddKey(0.15f, 0f);
            colorCurves.hueVsSat.value.AddKey(0.85f, 0f);
        }
    }

    public void SetCurrentColor(string color)
    {
        currentColor = color;
        playerController.SetSelfColor(color);
        rbControl.ChangeState(color);
    }

    public string GetCurrentColor()
    {
        return currentColor;
    }


    public void AddBlue()
    {
        if (volume.profile.TryGet(out colorCurves))
        {
            colorCurves.hueVsSat.value.AddKey(0.5f, 0);
            colorCurves.hueVsSat.value.AddKey(0.6f, 0.5f);
            colorCurves.hueVsSat.value.AddKey(0.7f, 0);
        }
    }

    public void AddRed()
    {
        if (volume.profile.TryGet(out colorCurves))
        {
            colorCurves.hueVsSat.value.AddKey(0f, 0.5f);
            //colorCurves.hueVsSat.value.AddKey(0.5f, 0);
            //colorCurves.hueVsSat.value.AddKey(0.6f, 0.5f);
            //colorCurves.hueVsSat.value.AddKey(0.7f, 0);
            colorCurves.hueVsSat.value.AddKey(1f, 0.5f);
        }
    }

    public void AddGreen()
    {
        if (volume.profile.TryGet(out colorCurves))
        {
            colorCurves.hueVsSat.value.AddKey(0.35f, 0.5f);
            colorCurves.hueVsSat.value.AddKey(0.5f, 0f);
        }
    }
}
