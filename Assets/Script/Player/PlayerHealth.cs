using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;

    [Header("UI 연결")]
    public Slider hpSlider;
    public TextMeshProUGUI hpText;

    [Header("무덤 프리팹 연결")]
    public GameObject gravePrefab;

    [Header("무적 관련")]
    public float invincibleTime = 0.5f;
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return; // 무적이면 데미지 무시

        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPUI();

        if (currentHP <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        float blinkInterval = 0.1f;
        float elapsed = 0f;

        while (elapsed < invincibleTime)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval / 2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval / 2f);
            elapsed += blinkInterval;
        }

        isInvincible = false;
    }

    public void HealFull()
    {
        currentHP = maxHP;
        UpdateHPUI();
    }

    public void UpdateHPUI()
    {
        if (hpSlider != null)
        {
            hpSlider.maxValue = maxHP;
            hpSlider.value = currentHP;
        }

        if (hpText != null)
        {
            hpText.text = $"{currentHP} / {maxHP}";
        }
    }

    void Die()
    {
        Debug.Log("플레이어 사망!");

        PlayerExp exp = GetComponent<PlayerExp>();
        int lostExp = 0;
        if (exp != null)
        {
            lostExp = exp.currentExp;

            exp.currentExp = 0;
            exp.level = 1;

            exp.UpdateUI();
        }

        if (gravePrefab != null)
        {
            GameObject grave = Instantiate(gravePrefab, transform.position, Quaternion.identity);
            grave.GetComponent<Grave>().storedExp = lostExp;
        }

        maxHP = 5;
        currentHP = maxHP;
        UpdateHPUI();

        transform.position = new Vector3(0, 0, 0);
    }
}
