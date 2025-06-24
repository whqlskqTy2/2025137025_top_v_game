using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    public int storedExp = 0; // 저장된 경험치

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExp exp = other.GetComponent<PlayerExp>();
            if (exp != null)
            {
                int recovered = Mathf.FloorToInt(storedExp * 0.3f);
                exp.GainExp(recovered);
                Debug.Log($"무덤에서 경험치 {recovered} 회수!");
            }

            Destroy(gameObject); // 무덤 사라짐
        }
    }
}
