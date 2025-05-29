using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log($"몬스터 데미지: -{amount}, 남은 체력: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("몬스터 처치됨!");
        Destroy(gameObject);
    }
    // 충돌 감지 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
            if (hp != null)
            {
                hp.TakeDamage(1);
            }
        }
    }
}