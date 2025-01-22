using UnityEngine;


public class StartMenu : MonoBehaviour
{
    public GameObject startPanel; // StartPanel을 연결

    public void StartGame()
    {
        // 게임 시작 시 패널 숨기기
        startPanel.SetActive(false);
        Debug.Log("Game Started!");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited!");
    }
}