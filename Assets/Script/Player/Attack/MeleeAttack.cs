using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public LayerMask enemyLayer;
    public int damage = 1;

    public int attackDamage = 1;

    public float attackCooldown = 0.5f; // ��Ÿ��
    private float lastAttackTime = -999f;

    private Animator animator;
    private CooldownUIManager uiManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        uiManager = FindObjectOfType<CooldownUIManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= lastAttackTime + attackCooldown)
        {
            animator.SetTrigger("Attack");
            Attack();
            lastAttackTime = Time.time;
            uiManager?.StartMeleeCooldown(attackCooldown);
        }
    }

    void Attack()
    {
        // ���� ���� �� ������
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Monster>()?.TakeDamage(damage);
            Debug.Log("���� Ÿ��!");
        }

        // ����ü ���� �� ����
        Collider2D[] hitProjectiles = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Projectile"));
        foreach (Collider2D proj in hitProjectiles)
        {
            Debug.Log("����ü �ı�!");
            Destroy(proj.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
} 
