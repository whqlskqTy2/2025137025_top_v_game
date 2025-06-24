using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// ������ �����͸� �����ϴ� Ŭ���� (GameObject�� ������ ����)

public class SaveManager : MonoBehaviour
{
    string saveFilePath;
    public GameObject player; // ������ �÷��̾� ������Ʈ

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        if (File.Exists(saveFilePath))
        {
            Debug.Log(" ���� ������ �����մϴ�: " + saveFilePath);
        }
        else
        {
            Debug.Log(" ���� ������ �����ϴ�.");
        }

        // �ڵ� �ε�
        LoadPlayerData();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log(" F5 ���� - ���� ����");
            SavePlayerData();
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            Debug.Log(" F9 ���� - �ҷ����� ����");
            LoadPlayerData();
        }
    }

    public void SavePlayerData()
    {
        if (player == null)
        {
            Debug.LogWarning("�÷��̾ �������� �ʾҽ��ϴ�.");
            return;
        }

        PlayerExp exp = player.GetComponent<PlayerExp>();
        PlayerHealth hp = player.GetComponent<PlayerHealth>();
        MeleeAttack attack = player.GetComponent<MeleeAttack>();

        PlayerSaveData data = new PlayerSaveData();

        if (exp != null)
        {
            data.level = exp.level;
            data.currentExp = exp.currentExp;
        }

        if (hp != null)
        {
            data.maxHP = hp.maxHP;
            data.currentHP = hp.currentHP;
        }

        if (attack != null)
        {
            data.attackPower = attack.attackDamage;
        }

        Vector2 pos = player.transform.position;
        data.position = new float[] { pos.x, pos.y };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);

        Debug.Log(" ���� �Ϸ�: " + saveFilePath);
    }

    public void LoadPlayerData()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("�ε� ���� - ���� ������ �����ϴ�.");
            return;
        }

        string json = File.ReadAllText(saveFilePath);
        PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json);

        if (player == null || data == null)
        {
            Debug.LogWarning("�ε� ���� - �÷��̾ ���ų� �����Ͱ� �����ϴ�.");
            return;
        }

        PlayerExp exp = player.GetComponent<PlayerExp>();
        PlayerHealth hp = player.GetComponent<PlayerHealth>();
        MeleeAttack attack = player.GetComponent<MeleeAttack>();

        if (exp != null)
        {
            exp.level = data.level;
            exp.currentExp = data.currentExp;
            exp.UpdateUI();
        }

        if (hp != null)
        {
            hp.maxHP = data.maxHP;
            hp.currentHP = data.currentHP;
            hp.UpdateHPUI();
        }

        if (attack != null)
        {
            attack.attackDamage = data.attackPower;
        }

        player.transform.position = new Vector2(data.position[0], data.position[1]);

        Debug.Log(" ���� ������ �ҷ����� �Ϸ�");
    }
}
