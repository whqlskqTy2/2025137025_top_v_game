using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string endingSceneName = "EndingScene"; // 인스펙터에서 수정 가능

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (KeyController.hasKey)
            {
                Debug.Log("문 통과! 게임 종료 씬으로 이동");
                SceneManager.LoadScene(endingSceneName); // 엔딩 씬으로 전환
            }
            else
            {
                Debug.Log("열쇠가 필요합니다.");
            }
        }
    }
}
