using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public GameObject summonPrefab;       // ��ȯ�� ���� ������
    public Transform summonPoint;         // ��ȯ ��ġ
    public float summonInterval = 3f;     // ��ȯ �ֱ�
    public int maxSummons = 3;            // �ִ� ��ȯ��

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

            // ���� ��ȯ�� ���� ���� Ȯ��
            summonedList.RemoveAll(item => item == null); // ���� ���� ����

            if (summonedList.Count < maxSummons)
            {
                GameObject newSummon = Instantiate(summonPrefab, summonPoint.position, Quaternion.identity);
                summonedList.Add(newSummon);
            }
        }
    }
}
