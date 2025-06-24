using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string endingSceneName = "EndingScene"; // �ν����Ϳ��� ���� ����

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (KeyController.hasKey)
            {
                Debug.Log("�� ���! ���� ���� ������ �̵�");
                SceneManager.LoadScene(endingSceneName); // ���� ������ ��ȯ
            }
            else
            {
                Debug.Log("���谡 �ʿ��մϴ�.");
            }
        }
    }
}
