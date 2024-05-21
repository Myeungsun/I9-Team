using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; 

    void Start()
    {
        LoadScoreBoard();
    }

    private void LoadScoreBoard()
    {
        // 저장된 최고 점수를 불러옴
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"Best Score: {highScore} M";
    }
}
