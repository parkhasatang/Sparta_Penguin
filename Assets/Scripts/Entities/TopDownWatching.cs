using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class TopDownWatching : MonoBehaviour
{

    [SerializeField] private SpriteRenderer watchRenderer;

    [SerializeField] private SpriteRenderer characterRanderer;

    //�� �Լ����� �ٶ���� �ϴ� ���� �ʿ��ϴ� �Ʒ�ó�� ������ش�.
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
        //�ٶ󺸴� ������ ���Ϳ��� ���� ���ϴ� �ڵ�//Atan�� ��ũź��Ʈ�� ���� ���� ���´�.
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//���� ������ ���Ϸ� ������ ��ȯ

        //������ ��꿡�� 90�� �̻��̸� ������ �ٲ��ִ� �ڵ�.
        watchRenderer.flipY = Mathf.Abs(rotz) > 90f;
        characterRanderer.flipX = watchRenderer.flipY;
        //���� ���� ȸ�� ��Ű��.
        //armPivot.rotation = Quaternion.Euler(0, 0, rotz);//rotz�� ���Ϸ� ����(������ ������ ���Ϸ��� �ٲ�)
    }
}
