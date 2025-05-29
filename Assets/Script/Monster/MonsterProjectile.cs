using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth hp = other.GetComponent<PlayerHealth>();
            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
            Destroy(gameObject); // �浹 �� ����
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Destroy(gameObject); // ���� ��Ƶ� ����
        }
    }
}