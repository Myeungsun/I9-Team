using UnityEngine;

public class DifficultyVisualsManager : MonoBehaviour
{
    public GameObject easyBackground;
    public GameObject normalBackground;
    public GameObject hardBackground;

    void Start()
    {
        SetDifficultyVisuals();
    }

    private void SetDifficultyVisuals()
    {
        FallingObjectManager.Difficulty savedDifficulty = (FallingObjectManager.Difficulty)PlayerPrefs.GetInt("GameDifficulty", (int)FallingObjectManager.Difficulty.Normal);

        // 모든 배경 오브젝트를 비활성화
        easyBackground.SetActive(false);
        normalBackground.SetActive(false);
        hardBackground.SetActive(false);

        // 저장된 난이도에 따라 해당하는 배경 오브젝트를 활성화
        switch (savedDifficulty)
        {
            case FallingObjectManager.Difficulty.Easy:
                easyBackground.SetActive(true);
                break;
            case FallingObjectManager.Difficulty.Normal:
                normalBackground.SetActive(true);
                break;
            case FallingObjectManager.Difficulty.Hard:
                hardBackground.SetActive(true);
                break;
        }
    }
}
