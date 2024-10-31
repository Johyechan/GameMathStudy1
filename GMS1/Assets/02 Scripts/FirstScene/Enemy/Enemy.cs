using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstScene
{
    public class Enemy : HitObject
    {
        private EnemyMovement _enemyMovement;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }

        private void Update()
        {
            _enemyMovement.Move();
        }

        public override void Hit()
        {
            Debug.Log("Enemy Hit");
            _enemyMovement.StopImmediately();
        }
    }
}

