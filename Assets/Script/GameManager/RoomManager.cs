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
            Debug.Log($" �� ��ϵ�: {door.name}");
        }
        else
        {
            Debug.Log($" �ߺ��� �� ��� �õ�: {door.name}");
        }
    }

    public void RegisterMonster(GameObject monster)
    {
        monsterCount++;
        Debug.Log($" ���� ��ϵ�. ���� ���� ��: {monsterCount}");
    }

    public void NotifyMonsterDeath()
    {
        monsterCount--;
        Debug.Log($" ���� ��� �����. ���� ���� ��: {monsterCount}");

        if (monsterCount <= 0)
        {
            Debug.Log(" �� ���� ���� ������. �� ���� ����!");
            OpenDoors();
        }
    }

    private void OpenDoors()
    {
        Debug.Log($" ���� �� ����: {doors.Count}");

        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                Debug.Log($" �� ���ŵ�: {door.name}");
                Destroy(door);
            }
        }

        Debug.Log(" �� ����: ��� ���� óġ��!");
    }
}

