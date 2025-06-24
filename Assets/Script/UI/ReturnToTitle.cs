using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public string titleSceneName = "MainMenu"; // 타이틀 씬 이름 입력

    public void GoToTitle()
    {
        SceneManager.LoadScene(titleSceneName);
    }
}
