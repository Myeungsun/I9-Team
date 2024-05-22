using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedMultiplier = 0.5f; // 속도 증가 배율
    public float duration = 5f; // 속도 증가 지속 시간
    public float speed = 20f;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < 50)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            Debug.Log("GGGGG");
        }
        if (collision.gameObject.CompareTag("Player")) // 플레이어와 충돌했는지 확인
        {
            TopDownMovement playerMovement = collision.gameObject.GetComponent<TopDownMovement>();
            if (playerMovement != null)
            {
                Debug.Log("speed");
                playerMovement.BoostSpeed(playerMovement.moveSpeed * speedMultiplier, duration);
            }
            Destroy(gameObject); // 아이템 사용 후 제거
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //벽 충돌 무시 ㅇㅇ
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        if (collision.gameObject.CompareTag("Meteor"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

}