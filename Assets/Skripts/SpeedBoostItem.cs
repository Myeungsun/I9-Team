using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedMultiplier = 2f; // �ӵ� ���� ����
    public float duration = 5f; // �ӵ� ���� ���� �ð�

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player")) // �÷��̾�� �浹�ߴ��� Ȯ��
        //{
        //    PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        //    if (playerMovement != null)
        //    {
        //        playerMovement.ChangeSpeed(playerMovement.moveSpeed * speedMultiplier, duration);
        //    }
        //    Destroy(gameObject); // ������ ��� �� ����
        //}
    }
}