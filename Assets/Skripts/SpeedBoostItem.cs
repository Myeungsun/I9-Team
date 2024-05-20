using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedMultiplier = 2f; // �ӵ� ���� ����
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            Debug.Log("GGGGG");
        }
        if (other.gameObject.CompareTag("Player")) // �÷��̾�� �浹�ߴ��� Ȯ��
        {
            TopDownMovement playerMovement = other.GetComponent<TopDownMovement>();
            if (playerMovement != null)
            {
                playerMovement.BoostSpeed(playerMovement.moveSpeed * speedMultiplier, duration);
            }
            Destroy(gameObject); // ������ ��� �� ����
        }
    }
}