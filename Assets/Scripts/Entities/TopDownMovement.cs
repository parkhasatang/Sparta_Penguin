using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer watchRenderer;//캐릭터 바라보는 시점에 따라 방향바뀌기 구현

    private TopDownCharacterController _controller;

    public Animator animator;
    

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    public GameManager manager;

    public GameObject targetObject;

    // 마우스 더블 클릭 변수
    private float lastClickTime = 0f;
    public float doubleClickTimeThreshold = 0.3f;

    //Vector2 mousePosition;
    //Vector3 nowPosition;

    //Resolution Resolutions;
    //float X;
    //float Y;

    private void Awake()
    {
        manager.velocity = 1;
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();

        //해상도 값 //Screen.resolutions 가로 세로 픽셀수
        //Resolutions = Screen.currentResolution; //필드에선 실행 안됌.
        //X = Resolutions.width * 0.5f;
        //Y = Resolutions.height * 0.5f;
        //nowPosition = new Vector2(X, Y);
        //Debug.Log(nowPosition);

    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.OnLookEvent += OnAim;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))// 마우스를 더블 클릭하면 실행.
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTimeThreshold && targetObject != null )
            {
                // 마우스 더블클릭이 감지.
                //Debug.Log("Double Click!" + targetObject.name);
                manager.Talk(targetObject);
                Debug.Log("눌렸엉");
                
                //더블 클릭을 유도하는 창을 하나 만들어주자.
            }

            lastClickTime = Time.time;
        }

        if (Input.GetButtonDown("Jump")) //대화 UI창 닫아주는 역활.
        {
            manager.isTalking = false;
            manager.velocity = 1;
            manager._talkPanel.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);



        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        //Ray를 이용해서 npc와 상호작용을 할 수 있게 해준다.

        //이건 상관없는거임 = 부산물
        //Debug.DrawRay(_rigidbody.position, mouseWorldPosition *1f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, LayerMask.GetMask("NPC"));// 레이어를 NPC로 설정한 오브젝트만 스캔할 수 있다. // 거리를 빼줘서 어디서든 클릭해도 되게 해줬음.

        if(rayHit.collider != null)//rayhit로 닿은 오브젝트의 collider가 있을때
        {
            targetObject = rayHit.collider.gameObject;//변수로 저장
        }
        else
        {
            targetObject = null;
        }
        
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5* manager.velocity; ;// 게임 매니저에서 대화중이면 못움직이게 값을 0으로 만들어줌.
        _rigidbody.velocity = direction;
        animator.SetFloat("Velocity", Mathf.Abs(_rigidbody.velocity.x + _rigidbody.velocity.y + (_rigidbody.velocity.x * _rigidbody.velocity.y))) ;//유니티 Animator에 있는 Parameters안에 있는 변수이름을 ()안에 적어주면 된다.
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
