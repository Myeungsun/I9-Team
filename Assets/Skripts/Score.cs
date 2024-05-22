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
        // ���� ���� �� �ְ� ������ �ҷ���
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreTxt.text = $"Best Score: {highScore}";

        //Debug.Log(gameObject);
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

        // ���� ������ �ְ� ������ ������ �ְ� ������ ������Ʈ
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // �ְ� ������ ����
            PlayerPrefs.Save(); // ���� ������ ��� ����
        }

        // UI �ؽ�Ʈ ������Ʈ
        currentScoreTxt.text = $"Current Score: {currentScore}";
        highScoreTxt.text = $"Best Score: {highScore}";
    }
}
