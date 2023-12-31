using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    //이 스크립트에서 event를 입력처리하는 역활
    public static Camera _camera;
    public TMP_Text playerName; // 변경할 오브젝트를 넣어줄 칸 생성
    //다형성 = 상속 받은 클래스에 따라서 구현이 조금씩 달라지는것
    private void Awake() //다형성 예시 1 - public override void Awake()
    {
        // 다형성 예시 1 - base.Awake();
        _camera = Camera.main;//메인 카메라 찾아오기

        // 오브젝트 칸에 캐릭터 이름 설정
        String PlayerName = PlayerPrefs.GetString("PlayerName");
        playerName.text = PlayerName;
    }


    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);//moveInput이라는 매개변수값을 넣어 부모클래스의 함수 호출.
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position); //발사같은건 구현 안할 것이기 때문에 normalized 는 빼준다.
        
        
        if (newAim.magnitude >= .9f)//magnitude는 길이다. normalized로 길이를 1로 고정 시켜줘서 무조건 실행된다.
        {
            CallLookEvent(newAim);
        }

    }

    //OnInteractive로 f누를시 안에 npc가 있다면 실행되는 함수를 만들어주자.
}
