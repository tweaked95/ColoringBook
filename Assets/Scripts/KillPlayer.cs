using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public SceneController sceneController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            sceneController.GetFromCheckpoint();
        }
    }
}
