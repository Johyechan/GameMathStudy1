using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : PhysicsMovement
{
    private GameObject _playerObject;

    private void Start()
    {
        _playerObject = GameObject.Find("Player");
    }

    public override void Move()
    {
        if (_isStop)
            return;

        Vector3 playerPos = _playerObject.transform.position;
        Vector3 enemyPos = transform.position;

        Vector3 dir = playerPos - enemyPos;

        _rigidbody.velocity = dir.normalized * _Speed;
    }
}
