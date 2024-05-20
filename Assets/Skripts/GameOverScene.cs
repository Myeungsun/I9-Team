using Unity.VisualScripting;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    public GameObject gameOver;

    void Start() // 처음엔 게임종료 문구가 뜨지않음
    {
        gameOver.SetActive(false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor")) // 똥을 맞으면 ( poob 을 바꿔줘야 함 )
        {
            gameOver.SetActive(true); // 게임종료 문구가 뜸
            Meteor.Destroy(gameObject);
        }
    }

}
