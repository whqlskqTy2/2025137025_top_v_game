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
    public GameObject gravePrefab; // 🔹Inspector에서 프리팹 드래그 연결

    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPUI();

        if (currentHP <= 0)
        {
            Die();
        }
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
        Debug.Log(" 플레이어 사망!");

        PlayerExp exp = GetComponent<PlayerExp>();
        int lostExp = 0;
        if (exp != null)
        {
            lostExp = exp.currentExp;
            exp.currentExp = 0;
            exp.UpdateUI();
        }

        // 무덤 생성
        if (gravePrefab != null)
        {
            GameObject grave = Instantiate(gravePrefab, transform.position, Quaternion.identity);
            grave.GetComponent<Grave>().storedExp = lostExp;
        }

        //  플레이어를 죽이는 대신 리스폰 위치로 이동
        transform.position = new Vector3(0, 0, 0); // 예: 시작 위치로
        HealFull(); // 체력 회복
    }

}
