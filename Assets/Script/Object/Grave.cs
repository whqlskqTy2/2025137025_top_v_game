using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    public int storedExp = 0; // ����� ����ġ

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExp exp = other.GetComponent<PlayerExp>();
            if (exp != null)
            {
                int recovered = Mathf.FloorToInt(storedExp * 0.3f);
                exp.GainExp(recovered);
                Debug.Log($"�������� ����ġ {recovered} ȸ��!");
            }

            Destroy(gameObject); // ���� �����
        }
    }
}
