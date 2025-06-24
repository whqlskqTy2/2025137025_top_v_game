using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// 저장할 데이터를 정의하는 클래스 (GameObject에 붙이지 않음)

public class SaveManager : MonoBehaviour
{
    string saveFilePath;
    public GameObject player; // 저장할 플레이어 오브젝트

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        if (File.Exists(saveFilePath))
        {
            Debug.Log(" 저장 파일이 존재합니다: " + saveFilePath);
        }
        else
        {
            Debug.Log(" 저장 파일이 없습니다.");
        }

        // 자동 로드
        LoadPlayerData();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log(" F5 눌림 - 저장 실행");
            SavePlayerData();
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            Debug.Log(" F9 눌림 - 불러오기 실행");
            LoadPlayerData();
        }
    }

    public void SavePlayerData()
    {
        if (player == null)
        {
            Debug.LogWarning("플레이어가 지정되지 않았습니다.");
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

        Debug.Log(" 저장 완료: " + saveFilePath);
    }

    public void LoadPlayerData()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("로드 실패 - 저장 파일이 없습니다.");
            return;
        }

        string json = File.ReadAllText(saveFilePath);
        PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json);

        if (player == null || data == null)
        {
            Debug.LogWarning("로드 실패 - 플레이어가 없거나 데이터가 없습니다.");
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

        Debug.Log(" 저장 데이터 불러오기 완료");
    }
}
