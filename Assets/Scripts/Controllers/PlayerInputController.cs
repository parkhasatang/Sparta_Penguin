using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    //�� ��ũ��Ʈ���� event�� �Է�ó���ϴ� ��Ȱ
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;//���� ī�޶� ã�ƿ���
    }


    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);//moveInput�̶�� �Ű��������� �־� �θ�Ŭ������ �Լ� ȣ��.
    }

    public void OnLook(InputValue value)
    {

    }
}
