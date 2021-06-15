using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public GameObject SceneController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SceneController.GetComponent<SceneController>().SaveToCheckpoint();
        }
    }
}
