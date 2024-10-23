using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PhysicsMovement
{
    public override void Move()
    {
        if (_isStop)
            return;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 moveVec = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _rigidbody.velocity = moveVec * _Speed;
    }
}
