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
        if (collision.gameObject.CompareTag("Item"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    public void Initialize(FallingObjectManager.Difficulty difficulty)
    {
        switch (difficulty)
        {
            case FallingObjectManager.Difficulty.Easy:
                speed = 3f; // 쉬움 난이도의 속도 설정
                transform.localScale = new Vector3(30f, 30f, 30f); // 쉬움 난이도의 크기 설정
                break;
            case FallingObjectManager.Difficulty.Normal:
                speed = 5f; // 보통 난이도의 속도 설정
                transform.localScale = new Vector3(50f, 50f, 50f); // 보통 난이도의 크기 설정
                break;
            case FallingObjectManager.Difficulty.Hard:
                speed = 10f; // 어려움 난이도의 속도 설정
                transform.localScale = new Vector3(80f, 80f, 80f); // 어려움 난이도의 크기 설정
                break;
        }
    }
}
