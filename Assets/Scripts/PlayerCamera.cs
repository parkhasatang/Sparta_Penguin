using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; //���� �÷��̾ ������Ʈ ĭ���� �־��ش�.

    void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = player.position;
            playerPos.z = transform.position.z; // ī�޶��� z ��ǥ�� ����
            transform.position = playerPos;
        }
    }
}
