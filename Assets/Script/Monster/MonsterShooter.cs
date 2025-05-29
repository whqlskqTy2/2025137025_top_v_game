using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float projectileSpeed = 5f;
    public float attackRange = 6f;

    private Transform player;
    private float lastShootTime = -999f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time >= lastShootTime + shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
    }
}