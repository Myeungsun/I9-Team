using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;

    private float timeCounter = 0f;
    private int currentScore = 0;

    // ������ ���̵�
    private FallingObjectManager.Difficulty currentDifficulty;

    void Start()
    {
        // ���� ������ ���̵� ��������
        currentDifficulty = (FallingObjectManager.Difficulty)PlayerPrefs.GetInt("GameDifficulty", (int)FallingObjectManager.Difficulty.Normal);

        // �ش� ���̵��� ����� �ְ� ���� �ҷ�����
        int highScore = PlayerPrefs.GetInt(currentDifficulty.ToString() + "HighScore", 0);
        highScoreTxt.text = $"Best Score: {highScore}";
    }

    void Update()
    {
        // �ð��� ���� ���� ������ ������Ŵ
        timeCounter += Time.deltaTime;
        if (timeCounter >= 1f)
        {
            currentScore += 1;
            timeCounter = 0f;
        }

        // UI �ؽ�Ʈ ������Ʈ
        currentScoreTxt.text = $"Current Score: {currentScore}";
    }

    // ���� ���� �� �ְ� ���� ������Ʈ
    public void UpdateHighScore()
    {
        // ���� ������ ����� �ְ� ���� ���Ͽ� ������Ʈ
        int savedHighScore = PlayerPrefs.GetInt(currentDifficulty.ToString() + "HighScore", 0);
        if (currentScore > savedHighScore)
        {
            PlayerPrefs.SetInt(currentDifficulty.ToString() + "HighScore", currentScore);
            PlayerPrefs.Save();
        }
    }
}
