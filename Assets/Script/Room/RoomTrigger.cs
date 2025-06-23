using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject doorPrefab;
    public Transform[] doorSpawnPoints;

    [Header("몬스터 관련")]
    public GameObject[] monsterPrefabs; // 여러 종류의 몬스터 프리팹
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

            Debug.Log(" 플레이어 진입, 방 활성화됨");
            SpawnDoors();
            SpawnMonsters();
        }
    }

    private void SpawnMonsters()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        foreach (Transform spawnPoint in monsterSpawnPoints)
        {
            //  몬스터 종류를 랜덤으로 선택
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
                Debug.LogWarning(" RoomManager가 연결되지 않아 몬스터 등록 실패");
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
                Debug.LogWarning(" RoomManager가 연결되지 않아 문 등록 실패");
            }
        }
    }
}

