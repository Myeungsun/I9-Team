using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI easyHighScoreTxt;
    public TextMeshProUGUI normalHighScoreTxt;
    public TextMeshProUGUI hardHighScoreTxt;

    void Start()
    {
        // 각 난이도에 따른 최고 점수를 불러와 UI에 표시
        int easyHighScore = PlayerPrefs.GetInt(FallingObjectManager.Difficulty.Easy.ToString() + "HighScore", 0);
        easyHighScoreTxt.text = $"Easy Level: High Score: {easyHighScore}";

        int normalHighScore = PlayerPrefs.GetInt(FallingObjectManager.Difficulty.Normal.ToString() + "HighScore", 0);
        normalHighScoreTxt.text = $"Normal Level: High Score: {normalHighScore}";

        int hardHighScore = PlayerPrefs.GetInt(FallingObjectManager.Difficulty.Hard.ToString() + "HighScore", 0);
        hardHighScoreTxt.text = $"Hard Level: High Score: {hardHighScore}";
    }
}
