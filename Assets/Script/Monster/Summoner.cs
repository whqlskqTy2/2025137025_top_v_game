using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public GameObject summonPrefab;       // 소환할 몬스터 프리팹
    public Transform summonPoint;         // 소환 위치
    public float summonInterval = 3f;     // 소환 주기
    public int maxSummons = 3;            // 최대 소환수

    private List<GameObject> summonedList = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SummonRoutine());
    }

    IEnumerator SummonRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(summonInterval);

            // 현재 소환된 몬스터 개수 확인
            summonedList.RemoveAll(item => item == null); // 죽은 몬스터 정리

            if (summonedList.Count < maxSummons)
            {
                GameObject newSummon = Instantiate(summonPrefab, summonPoint.position, Quaternion.identity);
                summonedList.Add(newSummon);
            }
        }
    }
}
