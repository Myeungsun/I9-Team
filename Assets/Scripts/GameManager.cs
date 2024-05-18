using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool[] players = new bool[4];

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

}
