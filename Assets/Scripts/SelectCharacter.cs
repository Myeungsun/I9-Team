using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] playerSelects;

    private void Start()
    {
        LoadPlayerSelection();
    }

    public void SelectPlayer(int playerNumber)
    {
        for (int i = 0; i < playerSelects.Length; i++)
        {
            playerSelects[i].SetActive(i == playerNumber - 1);
        }
        GameManager.Getplayer(playerNumber, true);
    }

    private void LoadPlayerSelection()
    {
        for (int i = 0; i < GameManager.players.Length; i++)
        {
            if (GameManager.players[i])
            {
                playerSelects[i].SetActive(true);
                break;
            }
        }
    }
}
