using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private void Awake()
    {
        fallingObjectManager = FindObjectOfType<FallingObjectManager>();
        if (fallingObjectManager == null)
        {
            Debug.LogError("FallingObjectManager를 찾을 수 없습니다.");
        }
    }
    public FallingObjectManager fallingObjectManager;

    public void SetDifficultyEasy()
    {
        SetDifficulty(FallingObjectManager.Difficulty.Easy);
    }

    public void SetDifficultyNormal()
    {
        SetDifficulty(FallingObjectManager.Difficulty.Normal);
    }

    public void SetDifficultyHard()
    {
        SetDifficulty(FallingObjectManager.Difficulty.Hard);
    }

    private void SetDifficulty(FallingObjectManager.Difficulty difficulty)
    {
        fallingObjectManager.SetDifficulty(difficulty);
        PlayerPrefs.SetInt("GameDifficulty", (int)difficulty); // 현재 난이도를 저장합니다.
        PlayerPrefs.Save();
    }
}
