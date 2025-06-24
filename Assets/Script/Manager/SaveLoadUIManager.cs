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

            saveInfoText.text = $"����: {data.level}\n" +
                                $"����ġ: {data.currentExp}\n" +
                                $"ü��: {data.currentHP} / {data.maxHP}\n" +
                                $"���ݷ�: {data.attackPower}";
        }
        else
        {
            saveInfoText.text = "����� �����Ͱ� �����ϴ�.";
        }
    }

    // ��ư���� ������ �Լ�
    public void OnClickLoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            SceneManager.LoadScene("GameScene1"); //  �� �̸� �°� ����!
        }
    }

    public void OnClickDeleteSave()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("���� ������ ������!");
            UpdateSaveInfoUI(); // UI ������Ʈ
        }
    }
}