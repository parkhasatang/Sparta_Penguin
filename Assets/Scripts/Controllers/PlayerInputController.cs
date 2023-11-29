using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    //�� ��ũ��Ʈ���� event�� �Է�ó���ϴ� ��Ȱ
    private Camera _camera;
    public TMP_Text playerName; // ������ ������Ʈ�� �־��� ĭ ����

    private void Awake()
    {
        _camera = Camera.main;//���� ī�޶� ã�ƿ���

        // ������Ʈ ĭ�� ĳ���� �̸� ����
        String PlayerName = PlayerPrefs.GetString("PlayerName");
        playerName.text = PlayerName;
    }


    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);//moveInput�̶�� �Ű��������� �־� �θ�Ŭ������ �Լ� ȣ��.
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position); //�߻簰���� ���� ���� ���̱� ������ normalized �� ���ش�.
        
        
        if (newAim.magnitude >= .9f)//magnitude�� ���̴�. normalized�� ���̸� 1�� ���� �����༭ ������ ����ȴ�.
        {
            CallLookEvent(newAim);
        }

    }
}
