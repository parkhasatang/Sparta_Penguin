using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class TopDownWatching : MonoBehaviour
{

    [SerializeField] private SpriteRenderer watchRenderer;

    [SerializeField] private SpriteRenderer characterRanderer;

    //이 함수들이 바라봐야 하는 곳이 필요하니 아래처럼 만들어준다.
    private TopDownCharacterController _controller;


    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }


    public void OnAim(Vector2 newWatchDirection)
    {
        RotateWatching(newWatchDirection);
    }

    private void RotateWatching(Vector2 direction)
    {
        //바라보는 방향의 벡터에서 각도 구하는 코드//Atan는 아크탄젠트로 라디안 값이 나온다.
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//라디안 각도를 오일러 각도로 변환

        //각도를 계산에서 90도 이상이면 방향을 바꿔주는 코드.
        watchRenderer.flipY = Mathf.Abs(rotz) > 90f;
        characterRanderer.flipX = watchRenderer.flipY;
        //실제 무기 회전 시키기.
        //armPivot.rotation = Quaternion.Euler(0, 0, rotz);//rotz는 오일러 각도(위에서 라디안을 오일러로 바꿈)
    }
}
