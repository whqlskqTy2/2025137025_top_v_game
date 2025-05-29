using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    public Slider hpSlider;

    public float invincibleDuration = 1.5f;
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        currentHP -= amount;
        hpSlider.value = currentHP;
        Debug.Log($"플레이어 피격! 남은 체력: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Invincibility());
        }
    }

    void Die()
    {
        Debug.Log("플레이어 사망!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;

        // 깜빡임 효과
        float elapsed = 0f;
        while (elapsed < invincibleDuration)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f); // 반투명
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1, 1, 1, 1f); // 원래대로
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.2f;
        }

        isInvincible = false;
    }
}
