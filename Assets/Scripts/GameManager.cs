using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject meteor;
    public static bool[] players = new bool[4];
    public GameObject item;

    private float meteorSpawnInterval = 1f; // 기본 메테오 등장 간격

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public Difficulty currentDifficulty = Difficulty.Normal;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadPlayerStatus();
    }

    void Start()
    {
        // 난이도에 따라 메테오 등장 간격 설정
        SetDifficulty(currentDifficulty);

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

            // 메테오 스크립트 가져오기
            Meteor meteorScript = newMeteor.GetComponent<Meteor>();
            if (meteorScript != null)
            {
                // 난이도에 따른 메테오 초기화
                meteorScript.Initialize(currentDifficulty);
            }
        }
        else
        {
            Debug.LogError("Meteor prefab is not assigned in the inspector.");
        }
    }

public static void Getplayer(int num, bool value)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = false;
        }
        players[num - 1] = value;

        SavePlayerStatus();
    }

    private static void SavePlayerStatus()
    {
        for (int i = 0; i < players.Length; i++)
        {
            PlayerPrefs.SetInt("Player" + (i + 1) + "Status", players[i] ? 1 : 0);
        }
    }

    private void LoadPlayerStatus()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = PlayerPrefs.GetInt("Player" + (i + 1) + "Status", 0) == 1;
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
    }

    // 난이도 버튼 클릭 시 호출되는 메서드
    public void SetDifficultyEasy()
    {
        currentDifficulty = Difficulty.Easy;
    }

    public void SetDifficultyNormal()
    {
        currentDifficulty = Difficulty.Normal;
    }

    public void SetDifficultyHard()
    {
        currentDifficulty = Difficulty.Hard;
    }
}
