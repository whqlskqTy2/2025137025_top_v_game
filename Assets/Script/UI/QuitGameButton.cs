using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("���� ����"); // ������ �׽�Ʈ�� �α�

        Application.Quit(); // ���� ���� �� �����

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ����� ����ǰ�
#endif
    }
}
