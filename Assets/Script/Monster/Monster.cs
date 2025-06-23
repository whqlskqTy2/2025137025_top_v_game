using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    public int expReward = 5;

    private RoomManager roomManager;

    void Start()
    {
        currentHP = maxHP;

        //  자동으로 RoomManager 찾기
        roomManager = FindObjectOfType<RoomManager>();

        if (roomManager == null)
        {
            Debug.LogWarning($" {gameObject.name}: RoomManager가 씬에서 발견되지 않았습니다.");
        }
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

        // ✅ 경험치 획득
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            PlayerExp expSystem = playerObj.GetComponent<PlayerExp>();
            if (expSystem != null)
            {
                expSystem.GainExp(expReward);
            }
        }

        // ✅ RoomManager에 몬스터 사망 보고
        if (roomManager != null)
        {
            roomManager.NotifyMonsterDeath();
            Debug.Log(" RoomManager에게 몬스터 사망 보고 완료");
        }
        else
        {
            Debug.LogWarning(" RoomManager가 연결되어 있지 않아 문이 열리지 않습니다!");
        }

        Destroy(gameObject);
    }

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


