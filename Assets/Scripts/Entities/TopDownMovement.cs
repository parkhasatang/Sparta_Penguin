using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer watchRenderer;//ĳ���� �ٶ󺸴� ������ ���� ����ٲ�� ����

    private TopDownCharacterController _controller;

    public Animator animator;
    

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    public GameManager manager;

    public GameObject targetObject;

    // ���콺 ���� Ŭ�� ����
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

        //�ػ� �� //Screen.resolutions ���� ���� �ȼ���
        //Resolutions = Screen.currentResolution; //�ʵ忡�� ���� �ȉ�.
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
        if (Input.GetMouseButtonDown(0))// ���콺�� ���� Ŭ���ϸ� ����.
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTimeThreshold && targetObject != null )
            {
                // ���콺 ����Ŭ���� ����.
                //Debug.Log("Double Click!" + targetObject.name);
                manager.Talk(targetObject);
                Debug.Log("���Ⱦ�");
                
                //���� Ŭ���� �����ϴ� â�� �ϳ� ���������.
            }

            lastClickTime = Time.time;
        }

        if (Input.GetButtonDown("Jump")) //��ȭ UIâ �ݾ��ִ� ��Ȱ.
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
        //Ray�� �̿��ؼ� npc�� ��ȣ�ۿ��� �� �� �ְ� ���ش�.

        //�̰� ������°��� = �λ깰
        //Debug.DrawRay(_rigidbody.position, mouseWorldPosition *1f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, LayerMask.GetMask("NPC"));// ���̾ NPC�� ������ ������Ʈ�� ��ĵ�� �� �ִ�. // �Ÿ��� ���༭ ��𼭵� Ŭ���ص� �ǰ� ������.

        if(rayHit.collider != null)//rayhit�� ���� ������Ʈ�� collider�� ������
        {
            targetObject = rayHit.collider.gameObject;//������ ����
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
        direction = direction * 5* manager.velocity; ;// ���� �Ŵ������� ��ȭ���̸� �������̰� ���� 0���� �������.
        _rigidbody.velocity = direction;
        animator.SetFloat("Velocity", Mathf.Abs(_rigidbody.velocity.x + _rigidbody.velocity.y + (_rigidbody.velocity.x * _rigidbody.velocity.y))) ;//����Ƽ Animator�� �ִ� Parameters�ȿ� �ִ� �����̸��� ()�ȿ� �����ָ� �ȴ�.
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
