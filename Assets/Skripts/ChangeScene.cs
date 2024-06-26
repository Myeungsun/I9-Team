using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Text messageText;
    public DifficultyManager difficultyManager;

    private void Awake()
    {
        difficultyManager = FindObjectOfType<DifficultyManager>();

    }

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

    public void SetDifficultyAndStartGame(string difficulty) //게임 난이도 설정 후 게임 시작
    {
        if (difficultyManager == null)
        {
            Debug.LogError("DifficultyManager를 찾을 수 없습니다. 난이도를 설정할 수 없습니다.");
            return;
        }

        switch (difficulty)
        {
            case "Easy":
                difficultyManager.SetDifficultyEasy();
                break;
            case "Normal":
                difficultyManager.SetDifficultyNormal();
                break;
            case "Hard":
                difficultyManager.SetDifficultyHard();
                break;
        }

        GameScene(); // 게임 씬으로 이동
    }
}
