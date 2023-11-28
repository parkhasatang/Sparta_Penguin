using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer watchRenderer;//ĳ���� �ٶ󺸴� ������ ���� ����ٲ�� ����

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

    //���⼭���� ĳ���� ���� �ٶ󺸴� �޼��� ����
    public void OnAim(Vector2 newWatchDirection)
    {
        RotateWatching(newWatchDirection);
    }

    private void RotateWatching(Vector2 direction)
    {
        //�ٶ󺸴� ������ ���Ϳ��� ���� ���ϴ� �ڵ�//Atan�� ��ũź��Ʈ�� ���� ���� ���´�.
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//���� ������ ���Ϸ� ������ ��ȯ

        //������ ��꿡�� 90�� �̻��̸� ������ �ٲ��ִ� �ڵ�.
        watchRenderer.flipX = Mathf.Abs(rotz) > 90f;
        //���� ���� ȸ�� ��Ű��.
        //armPivot.rotation = Quaternion.Euler(0, 0, rotz);//rotz�� ���Ϸ� ����(������ ������ ���Ϸ��� �ٲ�)
    }
}
