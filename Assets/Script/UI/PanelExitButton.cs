using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelExitButton : MonoBehaviour
{
    public GameObject targetPanel; // ���� Panel ����

    public void ClosePanel()
    {
        if (targetPanel != null)
        {
            targetPanel.SetActive(false);
        }
    }
}
