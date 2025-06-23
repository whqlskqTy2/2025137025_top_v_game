using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUIManager : MonoBehaviour
{
    public Slider meleeSlider;
    public Slider rangedSlider;

    private float meleeCooldownTimer = 0f;
    private float meleeCooldownMax = 1f;

    private float rangedCooldownTimer = 0f;
    private float rangedCooldownMax = 1f;

    void Update()
    {
        // ���� ���� ��Ÿ��
        if (meleeCooldownTimer < meleeCooldownMax)
        {
            meleeCooldownTimer += Time.deltaTime;
            meleeSlider.value = Mathf.Clamp01(meleeCooldownTimer / meleeCooldownMax);
        }

        // ���Ÿ� ���� ��Ÿ��
        if (rangedCooldownTimer < rangedCooldownMax)
        {
            rangedCooldownTimer += Time.deltaTime;
            rangedSlider.value = Mathf.Clamp01(rangedCooldownTimer / rangedCooldownMax);
        }
    }

    public void StartMeleeCooldown(float duration)
    {
        meleeCooldownMax = duration;
        meleeCooldownTimer = 0f;
    }

    public void StartRangedCooldown(float duration)
    {
        rangedCooldownMax = duration;
        rangedCooldownTimer = 0f;
    }
}
