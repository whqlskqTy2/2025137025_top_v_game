using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("게임 종료"); // 에디터 테스트용 로그

        Application.Quit(); // 실제 빌드 시 종료됨

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서도 종료되게
#endif
    }
}
