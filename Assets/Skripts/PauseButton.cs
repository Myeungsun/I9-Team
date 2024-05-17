using UnityEngine;

public class PauseButton : MonoBehaviour
{

    bool Ispause;

    private void Start()
    {
        Ispause = false; // 처음엔 게임을 진행
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) // P 키, ESC 키를 누를 시 게임 정지
        {
            Ispause = !Ispause;
        }
        if (Ispause) // 게임 정지
        {
            Time.timeScale = 0;
        }
        else // 게임 재개
        {
            Time.timeScale = 1;
        }

    }
}