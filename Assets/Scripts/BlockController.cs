using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    bool onScreen;

    public Sprite spr;
    public string blockColor;

    public Camera mainCam;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spr;
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
