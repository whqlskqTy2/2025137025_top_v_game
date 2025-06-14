using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviorManager : MonoBehaviour
{
    [Header("공통 이동 설정")]
    public float moveSpeed = 2f;

    [Header("공통 사거리 설정")]
    public float attackRange = 6f;
    public float shootInterval = 2f;
    public float projectileSpeed = 5f;
    public int damage = 1;

    void Start()
    {
        // 모든 MonsterFollow에게 이동 속도 적용
        MonsterFollow[] movers = FindObjectsOfType<MonsterFollow>();
        foreach (MonsterFollow mf in movers)
        {
            mf.moveSpeed = moveSpeed;
        }

        // 모든 MonsterShooter에게 사거리 및 투사체 속도 적용
        MonsterShooter[] shooters = FindObjectsOfType<MonsterShooter>();
        foreach (MonsterShooter ms in shooters)
        {
            ms.attackRange = attackRange;
            ms.shootInterval = shootInterval;
            ms.projectileSpeed = projectileSpeed;
        }

        // 모든 Monster에게 데미지 설정 적용
        Monster[] monsters = FindObjectsOfType<Monster>();
        foreach (Monster m in monsters)
        {
            m.maxHP = damage;
        }

        Debug.Log($"🎯 총 {movers.Length}개 이동 몬스터 / {shooters.Length}개 원거리 몬스터에 설정 적용 완료");
    }
}
