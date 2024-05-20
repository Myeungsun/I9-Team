using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerInputController : TopDownController
{
    public GameObject[] players;

    private void Start()
    {
        LoadPlayerSelection();
    }

    private void LoadPlayerSelection()
    {
        for (int i = 0; i < GameManager.players.Length; i++)
        {
            players[i].SetActive(GameManager.players[i]);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            // 플레이어가 운석에 맞았을 때의 로직 추가
            Debug.Log("hit!!!!!!");
        }
    }
}
