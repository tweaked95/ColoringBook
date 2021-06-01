using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUnlocker : MonoBehaviour
{
    public string unlockedColor;

    public PlayerController playerController;
    public void UnlockColor()
    {
        playerController.AddColor(unlockedColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UnlockColor();
            Destroy(gameObject);
        }
    }
}
