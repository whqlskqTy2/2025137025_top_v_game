using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public static bool hasKey = false; // ���� ���� ���� (���� ����)

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasKey = true;
            Debug.Log("���� ȹ��!");
            Destroy(gameObject); // ���� �����
        }
    }
}