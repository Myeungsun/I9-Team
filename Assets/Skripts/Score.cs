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

    // 선택한 난이도
    private FallingObjectManager.Difficulty currentDifficulty;

    void Start()
    {
        // 현재 선택한 난이도 가져오기
        currentDifficulty = (FallingObjectManager.Difficulty)PlayerPrefs.GetInt("GameDifficulty", (int)FallingObjectManager.Difficulty.Normal);

        // 해당 난이도에 저장된 최고 점수 불러오기
        int highScore = PlayerPrefs.GetInt(currentDifficulty.ToString() + "HighScore", 0);
        highScoreTxt.text = $"Best Score: {highScore}";
    }

    void Update()
    {
        // 시간에 따라 현재 점수를 증가시킴
        timeCounter += Time.deltaTime;
        if (timeCounter >= 1f)
        {
            currentScore += 1;
            timeCounter = 0f;
        }

        // UI 텍스트 업데이트
        currentScoreTxt.text = $"Current Score: {currentScore}";
    }

    // 게임 종료 시 최고 점수 업데이트
    public void UpdateHighScore()
    {
        // 현재 점수와 저장된 최고 점수 비교하여 업데이트
        int savedHighScore = PlayerPrefs.GetInt(currentDifficulty.ToString() + "HighScore", 0);
        if (currentScore > savedHighScore)
        {
            PlayerPrefs.SetInt(currentDifficulty.ToString() + "HighScore", currentScore);
            PlayerPrefs.Save();
        }
    }
}
