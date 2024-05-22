using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedMultiplier = 0.5f; // �ӵ� ���� ����
    public float duration = 5f; // �ӵ� ���� ���� �ð�
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
        if (collision.gameObject.CompareTag("Player")) // �÷��̾�� �浹�ߴ��� Ȯ��
        {
            TopDownMovement playerMovement = collision.gameObject.GetComponent<TopDownMovement>();
            if (playerMovement != null)
            {
                Debug.Log("speed");
                playerMovement.BoostSpeed(playerMovement.moveSpeed * speedMultiplier, duration);
            }
            Destroy(gameObject); // ������ ��� �� ����
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //�� �浹 ���� ����
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