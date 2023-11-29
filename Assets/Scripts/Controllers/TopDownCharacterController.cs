using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // 다형성 예시 1
    //public virtual void Awake() //부모가 public으로 했으면 자식도 public으로 만들어줘야한다.
    //{
        
    //}

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
