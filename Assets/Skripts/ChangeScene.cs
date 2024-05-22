using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public Text messageText;

    public void MainScene() // 메인 창
    {
        Time.timeScale = 1f;
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
        if (IsAnyPlayerSelected())
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            ShowMessage("캐릭터를 선택해 주세요.");
        }
    }

    private bool IsAnyPlayerSelected()
    {
        foreach (bool player in GameManager.players)
        {
            if (player)
            {
                return true;
            }
        }
        return false;
    }

    private void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
            StartCoroutine(HideMessageAfterDelay(2f)); // 2초 후에 메시지 숨김
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    public void ScoreBoard() // 점수 창
    {
        SceneManager.LoadScene("ScoreBoard");
    }

    public void SetDifficultyAndStartGame(string difficulty) //게임 난이도
    {
        switch (difficulty)
        {
            case "Easy":
                GameManager.instance.SetDifficultyEasy();
                break;
            case "Normal":
                GameManager.instance.SetDifficultyNormal();
                break;
            case "Hard":
                GameManager.instance.SetDifficultyHard();
                break;
        }
        GameScene(); // 게임 씬으로 이동
    }
}
