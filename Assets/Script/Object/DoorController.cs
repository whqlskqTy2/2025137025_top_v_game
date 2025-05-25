using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (KeyController.hasKey)
            {
                Debug.Log("문 통과!");
                Destroy(gameObject); // 문 열림
            }
            else
            {
                Debug.Log("열쇠가 필요합니다.");
                // 아무 일도 일어나지 않음
            }
        }
    }
}
