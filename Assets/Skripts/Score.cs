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
    private int highScore = 0;
    private int currentScore = 0;

    void Start()
    {
        // 게임 시작 시 최고 점수를 불러옴
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreTxt.text = $"Best Score: {highScore}";

        //Debug.Log(gameObject);
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

        // 현재 점수가 최고 점수를 넘으면 최고 점수를 업데이트
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // 최고 점수를 저장
            PlayerPrefs.Save(); // 변경 사항을 즉시 저장
        }

        // UI 텍스트 업데이트
        currentScoreTxt.text = $"Current Score: {currentScore}";
        highScoreTxt.text = $"Best Score: {highScore}";
    }
}
