using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootForce = 10f;
    public float attackCooldown = 0.5f;

    private float lastAttackTime = -999f;

    //  추가: UI 연동용 변수
    private CooldownUIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<CooldownUIManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= lastAttackTime + attackCooldown)
        {
            Shoot();
            lastAttackTime = Time.time;

            //  추가: UI 쿨타임 바 실행
            uiManager?.StartRangedCooldown(attackCooldown);
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;

        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * shootForce;
    }
}