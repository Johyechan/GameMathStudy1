using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondScene
{
    public abstract class Movement : MonoBehaviour
    {
        protected Rigidbody _rigidbody;

        [SerializeField] protected float _Speed;

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public abstract void Move();
    }
}

