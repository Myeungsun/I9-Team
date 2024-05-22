using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    public GameObject meteor;
    public GameObject item;

    private float meteorSpawnInterval = 1f; // 기본 메테오 등장 간격
    public Difficulty currentDifficulty = Difficulty.Normal;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    private void Start()
    {
        // 게임 시작 시 저장된 난이도로 스폰을 시작합니다.
        Difficulty savedDifficulty = (Difficulty)PlayerPrefs.GetInt("GameDifficulty", (int)Difficulty.Normal);
        StartSpawning(savedDifficulty);
    }

    public void StartSpawning(Difficulty difficulty)
    {
        SetDifficulty(difficulty);
        InvokeRepeating("MakeMeteor", 1f, meteorSpawnInterval);
        InvokeRepeating("MakeItem", 1f, 2f);
    }

    void MakeMeteor()
    {
        if (meteor != null)
        {
            float x = Random.Range(0f, 760f);
            Vector3 spawnPosition = new Vector3(x, 1300, 0);
            GameObject newMeteor = Instantiate(meteor, spawnPosition, Quaternion.identity);

            Meteor meteorScript = newMeteor.GetComponent<Meteor>();
            if (meteorScript != null)
            {
                meteorScript.Initialize(currentDifficulty);
            }
        }
        else
        {
            Debug.LogError("Meteor prefab is not assigned in the inspector.");
        }
    }

    void MakeItem()
    {
        if (item != null)
        {
            float x = Random.Range(0f, 760f);
            Vector3 spawnPosition = new Vector3(x, 1300, 0);
            Instantiate(item, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Item prefab is not assigned in the inspector.");
        }
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        currentDifficulty = difficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                meteorSpawnInterval = 1f; // 쉬운 난이도: 메테오 등장 간격 1초
                break;
            case Difficulty.Normal:
                meteorSpawnInterval = 0.8f; // 보통 난이도: 메테오 등장 간격 0.8초
                break;
            case Difficulty.Hard:
                meteorSpawnInterval = 0.5f; // 어려운 난이도: 메테오 등장 간격 0.5초
                break;
        }

        CancelInvoke();
        InvokeRepeating("MakeMeteor", 1f, meteorSpawnInterval);
        InvokeRepeating("MakeItem", 1f, 2f);
    }
}
