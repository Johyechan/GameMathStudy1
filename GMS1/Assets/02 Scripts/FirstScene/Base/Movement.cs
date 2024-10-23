using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected bool _isStop;

    [SerializeField] protected float _Speed;

    public abstract void Move();

    public void StopImmediately()
    {
        _Speed = 0;
        _isStop = true;
    }
}
