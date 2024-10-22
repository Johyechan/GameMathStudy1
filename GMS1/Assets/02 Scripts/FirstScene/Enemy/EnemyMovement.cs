using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    private GameObject _gameObj;

    private void Start()
    {
        _gameObj = GameObject.Find("Player");
    }

    public override void Move()
    {
        if (_isStop)
            return;

        Vector3 playerPos = _gameObj.transform.position;
        Vector3 enemyPos = transform.position;

        Vector3 dir = playerPos - enemyPos;

        _rigidbody.velocity = dir.normalized * _Speed;
    }
}
