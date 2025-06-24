using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanelManager : MonoBehaviour
{
    public GameObject helpPanel;

    public void OpenHelp()
    {
        helpPanel.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPanel.SetActive(false);
    }
}

