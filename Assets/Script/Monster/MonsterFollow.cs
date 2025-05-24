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

