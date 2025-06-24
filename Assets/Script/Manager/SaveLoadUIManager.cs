using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveLoadUIManager : MonoBehaviour
{
    public TextMeshProUGUI saveInfoText;
    string saveFilePath;

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        UpdateSaveInfoUI();
    }

    void UpdateSaveInfoUI()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json);

            saveInfoText.text = $"레벨: {data.level}\n" +
                                $"경험치: {data.currentExp}\n" +
                                $"체력: {data.currentHP} / {data.maxHP}\n" +
                                $"공격력: {data.attackPower}";
        }
        else
        {
            saveInfoText.text = "저장된 데이터가 없습니다.";
        }
    }

    // 버튼에서 연결할 함수
    public void OnClickLoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            SceneManager.LoadScene("GameScene1"); //  씬 이름 맞게 변경!
        }
    }

    public void OnClickDeleteSave()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("저장 데이터 삭제됨!");
            UpdateSaveInfoUI(); // UI 업데이트
        }
    }
}