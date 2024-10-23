using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicsMovement : Movement
{
    protected Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
