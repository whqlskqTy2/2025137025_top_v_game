using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public int level = 1;
    public int currentExp = 0;
    public int expToNextLevel = 10;

    [Header("능력치 증가 설정")]
    public int hpIncreasePerLevel = 2;
    public int attackIncreasePerLevel = 1;

    [Header("UI 연결")]
    public TextMeshProUGUI levelText;
    public Slider expSlider;
    public TextMeshProUGUI expText;

    private PlayerHealth playerHealth;
    private MeleeAttack playerAttack;


    
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerAttack = GetComponent<MeleeAttack>();

        UpdateUI();
    }

    public void GainExp(int amount)
    {
        currentExp += amount;

        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }

        UpdateUI();
    }

    void LevelUp()
    {
        level++;
        expToNextLevel += 5;

        Debug.Log($"🌟 레벨 업! 현재 레벨: {level}");

        if (playerHealth != null)
        {
            playerHealth.maxHP += hpIncreasePerLevel;
            playerHealth.HealFull();
            playerHealth.UpdateHPUI();
        }

        if (playerAttack != null)
        {
            playerAttack.attackDamage += attackIncreasePerLevel;
        }
    }


    public void UpdateUI()
    {
        if (levelText != null) levelText.text = $"Lv. {level}";
        if (expSlider != null)
        {
            expSlider.maxValue = expToNextLevel;
            expSlider.value = currentExp;
        }
        if (expText != null) expText.text = $"{currentExp} / {expToNextLevel}";
    }
}

