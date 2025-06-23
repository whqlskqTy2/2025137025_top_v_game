using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    public Transform player;        // ������ ���
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        //  ���� �ܺο��� �� �־���ٸ� �ڵ����� ã�ƺ���
        if (player == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if (found != null)
            {
                player = found.transform;
                Debug.LogWarning($"{gameObject.name}: Player �ڵ� �����.");
            }
            else
            {
                Debug.LogWarning($"{gameObject.name}: Player�� ã�� �� ����.");
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        // �÷��̾� ���� ���
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
            Debug.Log("�÷��̾�� ����!"); // ���߿� ���ó��
        }
    }
}

