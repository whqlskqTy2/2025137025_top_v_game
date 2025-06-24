using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int currentExp = 0;
    public int maxHP = 10;
    public int currentHP = 10;
    public int attackPower = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5)) // ����
            PlayerDataManager.Save(this);

        if (Input.GetKeyDown(KeyCode.F9)) // �ҷ�����
            PlayerDataManager.Load(this);
    }

    public void RefreshStats()
    {
        // ü�� UI, ����ġ UI �� ���ΰ�ħ
        GetComponent<PlayerHealth>()?.UpdateHPUI();
        GetComponent<PlayerExp>()?.UpdateUI();
    }
}
