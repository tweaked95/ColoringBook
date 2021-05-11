using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    public GameObject blueRbs;
    public GameObject redRbs;
    public GameObject greenRbs;

    [SerializeField] List<Rigidbody2D> rbBlue = new List<Rigidbody2D>();
    [SerializeField] List<Rigidbody2D> rbRed = new List<Rigidbody2D>();
    [SerializeField] List<Rigidbody2D> rbGreen = new List<Rigidbody2D>();
    void Start()
    {
        FillList();
    }
 

    void FillList()
    {
        foreach (Rigidbody2D var in blueRbs.GetComponentsInChildren<Rigidbody2D>())
        {
            rbBlue.Add(var);
        }
        foreach (Rigidbody2D var in redRbs.GetComponentsInChildren<Rigidbody2D>())
        {
            rbRed.Add(var);
        }
        foreach (Rigidbody2D var in greenRbs.GetComponentsInChildren<Rigidbody2D>())
        {
            rbGreen.Add(var);
        }
    }

    public void ChangeState(string color)
    {
        if (color == "blue")
        {
            for (int i = 0; i < rbBlue.Count; i++)
            {
                rbBlue[i].GetComponent<BlockController>().SwitchToDynamic();
            }
            for (int i = 0; i < rbRed.Count; i++)
            {
                rbRed[i].GetComponent<BlockController>().SwitchToStatic();
            }
            for (int i = 0; i < rbGreen.Count; i++)
            {
                rbGreen[i].GetComponent<BlockController>().SwitchToStatic();
            }
        }
        else if (color == "red")
        {
            for (int i = 0; i < rbBlue.Count; i++)
            {
                rbBlue[i].GetComponent<BlockController>().SwitchToStatic();
            }
            for (int i = 0; i < rbRed.Count; i++)
            {
                rbRed[i].GetComponent<BlockController>().SwitchToDynamic();
            }
            for (int i = 0; i < rbGreen.Count; i++)
            {
                rbGreen[i].GetComponent<BlockController>().SwitchToStatic();
            }
        }
        else if (color == "green")
        {
            for (int i = 0; i < rbBlue.Count; i++)
            {
                rbBlue[i].GetComponent<BlockController>().SwitchToStatic();
            }
            for (int i = 0; i < rbRed.Count; i++)
            {
                rbRed[i].GetComponent<BlockController>().SwitchToStatic();
            }
            for (int i = 0; i < rbGreen.Count; i++)
            {
                rbGreen[i].GetComponent<BlockController>().SwitchToDynamic();
            }
        }
        else if(color == "default")
        {
            for (int i = 0; i < rbBlue.Count; i++)
            {
                rbBlue[i].GetComponent<BlockController>().SwitchToStatic();
            }
            for (int i = 0; i < rbRed.Count; i++)
            {
                rbRed[i].GetComponent<BlockController>().SwitchToStatic();
            }
            for (int i = 0; i < rbGreen.Count; i++)
            {
                rbGreen[i].GetComponent<BlockController>().SwitchToStatic();
            }
        }
    }
}
