using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MainScene() // ���� â
    {
        SceneManager.LoadScene("MainScene");
    }

    public void DifficultyScene() // ���̵� â
    {
        SceneManager.LoadScene("DifficultyScene");
    }

    public void CharacterScene() // ĳ���� ���� â
    {
        SceneManager.LoadScene("CharacterScene");
    }

    public void GameScene() // ���� ���� â
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ScoreBoard() // ���� â
    {
        SceneManager.LoadScene("ScoreBoard");
    }

}
