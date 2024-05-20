using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedMultiplier = 2f; // 속도 증가 배율
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            Debug.Log("GGGGG");
        }
        if (other.gameObject.CompareTag("Player")) // 플레이어와 충돌했는지 확인
        {
            TopDownMovement playerMovement = other.GetComponent<TopDownMovement>();
            if (playerMovement != null)
            {
                playerMovement.BoostSpeed(playerMovement.moveSpeed * speedMultiplier, duration);
            }
            Destroy(gameObject); // 아이템 사용 후 제거
        }
    }
}