using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject doorPrefab;
    public Transform[] doorSpawnPoints;

    [Header("���� ����")]
    public GameObject[] monsterPrefabs; // ���� ������ ���� ������
    public Transform[] monsterSpawnPoints;

    public RoomManager roomManager;

    private bool hasActivated = false;
    private float delay = 0.5f;

    void Update()
    {
        if (!hasActivated)
            delay -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!hasActivated && delay <= 0f && other.CompareTag("Player"))
        {
            hasActivated = true;

            Debug.Log(" �÷��̾� ����, �� Ȱ��ȭ��");
            SpawnDoors();
            SpawnMonsters();
        }
    }

    private void SpawnMonsters()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        foreach (Transform spawnPoint in monsterSpawnPoints)
        {
            //  ���� ������ �������� ����
            if (monsterPrefabs.Length == 0) continue;

            GameObject selectedPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
            GameObject monster = Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);

            MonsterFollow follow = monster.GetComponent<MonsterFollow>();
            if (follow != null && player != null)
                follow.player = player.transform;

            if (roomManager != null)
            {
                roomManager.RegisterMonster(monster);
            }
            else
            {
                Debug.LogWarning(" RoomManager�� ������� �ʾ� ���� ��� ����");
            }
        }
    }

    private void SpawnDoors()
    {
        foreach (Transform spawnPoint in doorSpawnPoints)
        {
            Quaternion rotation = Quaternion.identity;
            string name = spawnPoint.name.ToLower();

            if (name.Contains("top"))
                rotation = Quaternion.Euler(0f, 0f, 270f);
            else if (name.Contains("bottom"))
                rotation = Quaternion.Euler(0f, 0f, 90f);
            else if (name.Contains("right"))
                rotation = Quaternion.Euler(0f, 0f, 180f);

            GameObject door = Instantiate(doorPrefab, spawnPoint.position, rotation);

            if (roomManager != null)
            {
                roomManager.RegisterDoor(door);
            }
            else
            {
                Debug.LogWarning(" RoomManager�� ������� �ʾ� �� ��� ����");
            }
        }
    }
}

