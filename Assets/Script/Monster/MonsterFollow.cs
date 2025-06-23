using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    public Transform player;        // 추적할 대상
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        //  만약 외부에서 안 넣어줬다면 자동으로 찾아보기
        if (player == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if (found != null)
            {
                player = found.transform;
                Debug.LogWarning($"{gameObject.name}: Player 자동 연결됨.");
            }
            else
            {
                Debug.LogWarning($"{gameObject.name}: Player를 찾을 수 없음.");
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        // 플레이어 방향 계산
        Vector2 direction = (player.position - transform.position).normalized;
        moveDirection = direction;
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어에게 닿음!"); // 나중에 사망처리
        }
    }
}

