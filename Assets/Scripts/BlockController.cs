using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    bool onScreen;

    public string blockColor;
    public List<Material> mats;
    public Camera mainCam;

    void Start()
    {
        if (blockColor == "red")
        {
            GetComponent<MeshRenderer>().material = mats[0];
        }
        else if (blockColor == "green")
        {
            GetComponent<MeshRenderer>().material = mats[1];
        }
        else if (blockColor == "blue")
        {
            GetComponent<MeshRenderer>().material = mats[2];
        }
        else
        {
            Debug.Log("Can't apply correct material");
        }
    }

    public void ChangeMaterialColors(string unlockedColor)
    {
        if (unlockedColor == "red")
        {
            mats[0].SetFloat("_gotRed", 1.0f);
        }
        else if (unlockedColor == "green")
        {
            mats[1].SetFloat("_gotGreen", 1.0f);
        }
        else if (unlockedColor == "blue")
        {
            mats[2].SetFloat("_gotBlue", 1.0f);
        }
        else
        {
            Debug.Log("Couldn't change color properties");
        }
    }

    public void CheckScreenLocation()
    {
        Vector3 screenPoint = mainCam.WorldToViewportPoint(gameObject.transform.position);
        onScreen = (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1);
    }


    public void SwitchToDynamic()
    {
        CheckScreenLocation();
        if (onScreen)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void SwitchToStatic()
    {
        CheckScreenLocation();
        if (onScreen)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

}
