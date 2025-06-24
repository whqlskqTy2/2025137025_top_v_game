using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// ���ϸ�: PlayerSaveData.cs
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public int level;
    public int currentExp;
    public int maxHP;
    public int currentHP;
    public int attackPower;
    public float[] position;
}
