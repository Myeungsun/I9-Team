using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject meteor;
    public static bool[] players = new bool[4];
    public GameObject item;

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
        InvokeRepeating("MakeMeteor", 1f, 2f);
        InvokeRepeating("MakeItem", 1f, 2f);
    }

    void MakeMeteor()
    {
        if (meteor != null)
        {
            float x = Random.Range(0f, 760f); 
            Vector3 spawnPosition = new Vector3(x, 1300, 0); 
            Instantiate(meteor, spawnPosition, Quaternion.identity);
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
}
