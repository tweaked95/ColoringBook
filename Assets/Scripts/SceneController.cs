using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Linq;

public class SceneController : MonoBehaviour
{
    [SerializeField] string currentColor;

    public RigidBodyController rbControl;
    public PlayerController playerController;
    public UIController uiController;
    public Volume volume;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private List<GameObject> allObjects;
    [SerializeField]
    private List<Vector3> allObjectPositions;
    ColorCurves colorCurves;


    void Start()
    {
        currentColor = "default";
        if (volume.profile.TryGet(out colorCurves))
        {
            colorCurves.hueVsSat.value.AddKey(0.15f, 0f);
            colorCurves.hueVsSat.value.AddKey(0.85f, 0f);
        }
        AddObjectsToList();
        SaveToCheckpoint(); //Save checkpoint at the start of the game
    }

    void AddObjectsToList()
    {
        allObjects.AddRange(GameObject.FindGameObjectsWithTag("CheckpointValid"));
        allObjects.AddRange(GameObject.FindGameObjectsWithTag("Blocks"));
        allObjects.AddRange(GameObject.FindGameObjectsWithTag("MainCamera"));
        allObjects.Add(GameObject.FindGameObjectWithTag("Player"));

        for (int i = 0; i < allObjects.Count; i++)
        {
            allObjectPositions.Add(Vector3.zero);
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

    public void SaveToCheckpoint()
    {
        for (int i = 0; i < allObjects.Count; i++)
        {
            allObjectPositions[i] = allObjects[i].transform.position;
        }
    }

    public void GetFromCheckpoint()
    {
        for (int i = 0; i < allObjects.Count; i++)
        {
            if (allObjects[i].CompareTag("Player"))
            {
                TeleportCamera();
            }
            allObjects[i].SetActive(true);
            allObjects[i].transform.position = allObjectPositions[i];
            if (allObjects[i].TryGetComponent(out BlockController obj))
            {
                obj.SwitchToStatic();
            }
        }
        uiController.CloseSettings();
    }

    private void TeleportCamera()
    {
        virtualCamera.gameObject.SetActive(false);

        StartCoroutine(UpdateCameraFrameLater());
    }

    private IEnumerator UpdateCameraFrameLater()
    {
        yield return null;
        virtualCamera.gameObject.SetActive(true);
    }

    #region Add Colors
    public void AddBlue()
    {
        if (volume.profile.TryGet(out colorCurves))
        {
            colorCurves.hueVsSat.value.AddKey(0.5f, 0.5f);
            //colorCurves.hueVsSat.value.RemoveKey(0.5f);
            colorCurves.hueVsSat.value.AddKey(0.6f, 0.5f);
            colorCurves.hueVsSat.value.AddKey(0.7f, 0.5f);
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
            colorCurves.hueVsSat.value.AddKey(0.25f, 0.5f);
            colorCurves.hueVsSat.value.AddKey(0.4f, 0.5f);
            colorCurves.hueVsSat.value.AddKey(0.6f, 0f);
        }
    }
    #endregion
}
