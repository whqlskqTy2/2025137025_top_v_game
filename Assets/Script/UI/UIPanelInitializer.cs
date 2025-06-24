using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelInitializer : MonoBehaviour
{
    public GameObject[] panelsToDisable;

    void Start()
    {
        foreach (GameObject panel in panelsToDisable)
        {
            if (panel != null)
                panel.SetActive(false);
        }
    }
}
