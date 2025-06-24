using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePanelOpener : MonoBehaviour
{
    public GameObject savePanel;

    public void OpenSavePanel()
    {
        if (savePanel != null)
        {
            savePanel.SetActive(true);
        }
    }
}
