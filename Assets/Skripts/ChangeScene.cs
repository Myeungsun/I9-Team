using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public Text messageText;

    public void MainScene() // ���� â
    {
        Time.timeScale = 1f;
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
        if (IsAnyPlayerSelected())
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            ShowMessage("ĳ���͸� ������ �ּ���.");
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
            StartCoroutine(HideMessageAfterDelay(2f)); // 2�� �Ŀ� �޽��� ����
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

    public void ScoreBoard() // ���� â
    {
        SceneManager.LoadScene("ScoreBoard");
    }

    public void SetDifficultyAndStartGame(string difficulty) //���� ���̵�
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
        GameScene(); // ���� ������ �̵�
    }
}
