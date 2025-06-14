using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    public int storedExp = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExp exp = other.GetComponent<PlayerExp>();
            if (exp != null)
            {
                exp.GainExp(storedExp);
                Debug.Log($" �������� ����ġ {storedExp} ȸ��!");
            }

            Destroy(gameObject);
        }
    }
}
