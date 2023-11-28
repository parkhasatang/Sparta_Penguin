using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    //이 스크립트에서 event를 입력처리하는 역활
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;//메인 카메라 찾아오기
    }


    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);//moveInput이라는 매개변수값을 넣어 부모클래스의 함수 호출.
    }

    public void OnLook(InputValue value)
    {

    }
}
