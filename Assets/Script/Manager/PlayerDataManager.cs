using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PlayerDataManager
{
    private static string savePath = Application.persistentDataPath + "/playerData.json";

    public static void Save(Player player)
    {
        PlayerSaveData data = new PlayerSaveData
        {
            level = player.level,
            currentExp = player.currentExp,
            maxHP = player.maxHP,
            currentHP = player.currentHP,
            attackPower = player.attackPower,
            position = new float[] {
                player.transform.position.x,
                player.transform.position.y
            }
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log(" 저장 완료: " + savePath);
    }

    public static void Load(Player player)
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning(" 저장 파일 없음");
            return;
        }

        string json = File.ReadAllText(savePath);
        PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json);

        player.level = data.level;
        player.currentExp = data.currentExp;
        player.maxHP = data.maxHP;
        player.currentHP = data.currentHP;
        player.attackPower = data.attackPower;

        Vector3 loadedPos = new Vector3(data.position[0], data.position[1], 0);
        player.transform.position = loadedPos;

        player.RefreshStats(); // UI 업데이트, 체력바 등
        Debug.Log(" 불러오기 완료");
    }
}

