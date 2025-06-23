using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> doors = new List<GameObject>();
    private int monsterCount = 0;

    public void RegisterDoor(GameObject door)
    {
        if (!doors.Contains(door))
        {
            doors.Add(door);
            Debug.Log($" 문 등록됨: {door.name}");
        }
        else
        {
            Debug.Log($" 중복된 문 등록 시도: {door.name}");
        }
    }

    public void RegisterMonster(GameObject monster)
    {
        monsterCount++;
        Debug.Log($" 몬스터 등록됨. 현재 몬스터 수: {monsterCount}");
    }

    public void NotifyMonsterDeath()
    {
        monsterCount--;
        Debug.Log($" 몬스터 사망 보고됨. 남은 몬스터 수: {monsterCount}");

        if (monsterCount <= 0)
        {
            Debug.Log(" 문 열기 조건 만족됨. 문 열기 시작!");
            OpenDoors();
        }
    }

    private void OpenDoors()
    {
        Debug.Log($" 열릴 문 개수: {doors.Count}");

        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                Debug.Log($" 문 제거됨: {door.name}");
                Destroy(door);
            }
        }

        Debug.Log(" 문 열림: 모든 몬스터 처치됨!");
    }
}

