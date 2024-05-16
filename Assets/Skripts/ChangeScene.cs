using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MainScene() // 메인 창
    {
        SceneManager.LoadScene("MainScene");
    }

    public void DifficultyScene() // 난이도 창
    {
        SceneManager.LoadScene("DifficultyScene");
    }

    public void CharacterScene() // 캐릭터 선택 창
    {
        SceneManager.LoadScene("CharacterScene");
    }

    public void GameScene() // 게임 시작 창
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ScoreBoard() // 점수 창
    {
        SceneManager.LoadScene("ScoreBoard");
    }

}
