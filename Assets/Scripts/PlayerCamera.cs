using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; //따라갈 플레이어를 오브젝트 칸에서 넣어준다.

    void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = player.position;
            playerPos.z = transform.position.z; // 카메라의 z 좌표를 유지
            transform.position = playerPos;
        }
    }
}
