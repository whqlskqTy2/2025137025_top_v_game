using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public string titleSceneName = "MainMenu"; // Ÿ��Ʋ �� �̸� �Է�

    public void GoToTitle()
    {
        SceneManager.LoadScene(titleSceneName);
    }
}
