using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // 메인 씬 이름 입력

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
