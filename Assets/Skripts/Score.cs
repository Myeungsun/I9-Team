using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    private float timeCounter=0;
    private int highScore = 0;
    int currentScore = 0;

    void Update()
    {
        
        timeCounter += Time.deltaTime;
        if(timeCounter >=1f)
        {
            currentScore += (int)timeCounter;
            timeCounter = 0;
        }
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // 최고 점수를 저장
            PlayerPrefs.Save(); // 변경 사항을 즉시 저장
        }

        currentScoreTxt.text = $"Current Score:{currentScore} M";
        HighScoreTxt.text = $"Best Score:{highScore} M";
    }
}
