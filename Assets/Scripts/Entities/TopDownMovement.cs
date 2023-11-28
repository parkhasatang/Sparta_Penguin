using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer watchRenderer;//캐릭터 바라보는 시점에 따라 방향바뀌기 구현

    private TopDownCharacterController _controller;


    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.OnLookEvent += OnAim;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        _rigidbody.velocity = direction;
    }

    //여기서부터 캐릭터 시점 바라보는 메서드 구현
    public void OnAim(Vector2 newWatchDirection)
    {
        RotateWatching(newWatchDirection);
    }

    private void RotateWatching(Vector2 direction)
    {
        //바라보는 방향의 벡터에서 각도 구하는 코드//Atan는 아크탄젠트로 라디안 값이 나온다.
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//라디안 각도를 오일러 각도로 변환

        //각도를 계산에서 90도 이상이면 방향을 바꿔주는 코드.
        watchRenderer.flipX = Mathf.Abs(rotz) > 90f;
        //실제 무기 회전 시키기.
        //armPivot.rotation = Quaternion.Euler(0, 0, rotz);//rotz는 오일러 각도(위에서 라디안을 오일러로 바꿈)
    }
}
