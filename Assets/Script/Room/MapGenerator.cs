using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public int roomCount = 5;
    public Vector2 roomSpacing = new Vector2(10f, 10f);
    public RoomManager roomManager;

    private List<Vector2Int> usedPositions = new List<Vector2Int>();
    private Dictionary<Vector2Int, RoomInstance> roomMap = new Dictionary<Vector2Int, RoomInstance>();

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        Vector2Int currentPos = Vector2Int.zero;
        usedPositions.Add(currentPos);

        SpawnRoom(currentPos);

        for (int i = 1; i < roomCount; i++)
        {
            Vector2Int newPos = GetNewPosition();
            if (newPos != Vector2Int.zero)
            {
                usedPositions.Add(newPos);
                SpawnRoom(newPos);
            }
        }

        ConnectDoors();
    }

    void SpawnRoom(Vector2Int gridPos)
    {
        Vector3 worldPos = new Vector3(gridPos.x * roomSpacing.x, gridPos.y * roomSpacing.y, 0f);
        GameObject roomObj = Instantiate(roomPrefab, worldPos, Quaternion.identity);

        RoomTrigger trigger = roomObj.GetComponent<RoomTrigger>();
        if (trigger != null && roomManager != null)
        {
            trigger.roomManager = roomManager;
        }

        RoomInstance room = new RoomInstance
        {
            roomObject = roomObj,
            gridPosition = gridPos
        };

        foreach (Transform child in roomObj.transform)
        {
            if (child.name.StartsWith("DoorSpawn_"))
            {
                string dir = child.name.Replace("DoorSpawn_", "");
                room.doorPoints[dir] = child.gameObject;
                child.gameObject.SetActive(false); // ±âº» ²¨Áü
            }
        }

        roomMap[gridPos] = room;
    }

    Vector2Int GetNewPosition()
    {
        int tries = 0;
        while (tries < 20)
        {
            Vector2Int basePos = usedPositions[Random.Range(0, usedPositions.Count)];
            Vector2Int offset = GetRandomDirection();
            Vector2Int newPos = basePos + offset;

            if (!usedPositions.Contains(newPos))
                return newPos;

            tries++;
        }
        return Vector2Int.zero;
    }

    Vector2Int GetRandomDirection()
    {
        Vector2Int[] dirs = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        return dirs[Random.Range(0, dirs.Length)];
    }

    void ConnectDoors()
    {
        foreach (var kvp in roomMap)
        {
            var pos = kvp.Key;
            var room = kvp.Value;

            // ¿À¸¥ÂÊ
            if (roomMap.ContainsKey(pos + Vector2Int.right))
            {
                EnableDoor(room, "Right");
                EnableDoor(roomMap[pos + Vector2Int.right], "Left");
            }
            // ¿ÞÂÊ
            if (roomMap.ContainsKey(pos + Vector2Int.left))
            {
                EnableDoor(room, "Left");
                EnableDoor(roomMap[pos + Vector2Int.left], "Right");
            }
            // À§
            if (roomMap.ContainsKey(pos + Vector2Int.up))
            {
                EnableDoor(room, "Top");
                EnableDoor(roomMap[pos + Vector2Int.up], "Bottom");
            }
            // ¾Æ·¡
            if (roomMap.ContainsKey(pos + Vector2Int.down))
            {
                EnableDoor(room, "Bottom");
                EnableDoor(roomMap[pos + Vector2Int.down], "Top");
            }
        }
    }

    void EnableDoor(RoomInstance room, string direction)
    {
        if (room.doorPoints.ContainsKey(direction))
        {
            room.doorPoints[direction].SetActive(true);
        }
    }
}

public class RoomInstance
{
    public GameObject roomObject;
    public Vector2Int gridPosition;
    public Dictionary<string, GameObject> doorPoints = new Dictionary<string, GameObject>();
}
