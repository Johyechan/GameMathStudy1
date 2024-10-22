using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected Rigidbody _rigidbody;

    protected bool _isStop;

    [SerializeField] protected float _Speed;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public abstract void Move();

    public void StopImmediately()
    {
        _rigidbody.velocity = Vector3.zero;
        _isStop = true;
    }
}
