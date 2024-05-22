using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 5f;

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
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    // ���̵��� ���� ���׿� ����
    public void Initialize(GameManager.Difficulty difficulty)
    {
        switch (difficulty)
        {
            case GameManager.Difficulty.Easy:
                speed = 3f; // ���� ���̵��� �ӵ� ����
                transform.localScale = new Vector3(30f, 30f, 30f); // ���� ���̵��� ũ�� ����
                break;
            case GameManager.Difficulty.Normal:
                speed = 5f; // ���� ���̵��� �ӵ� ����
                transform.localScale = new Vector3(50f, 50f, 50f); // ���� ���̵��� ũ�� ����
                break;
            case GameManager.Difficulty.Hard:
                speed = 10f; // ����� ���̵��� �ӵ� ����
                transform.localScale = new Vector3(80f, 80f, 80f); // ����� ���̵��� ũ�� ����
                break;
        }
    }
}
