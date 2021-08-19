using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextController : MonoBehaviour
{
    public GameObject uiTooltipObject;
    public GameObject uiTooltipText;

    [Multiline]
    public string tooltipText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uiTooltipObject.SetActive(true);
            uiTooltipText.GetComponent<Text>().text = tooltipText;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uiTooltipObject.SetActive(false);

        }
    }
}
