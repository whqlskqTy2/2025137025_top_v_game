using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (KeyController.hasKey)
            {
                Debug.Log("�� ���!");
                Destroy(gameObject); // �� ����
            }
            else
            {
                Debug.Log("���谡 �ʿ��մϴ�.");
                // �ƹ� �ϵ� �Ͼ�� ����
            }
        }
    }
}
