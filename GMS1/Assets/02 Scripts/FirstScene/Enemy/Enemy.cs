using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HitObject
{
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        
    }

    public override void Hit()
    {
        Debug.Log("Enemy Hit");
    }
}
