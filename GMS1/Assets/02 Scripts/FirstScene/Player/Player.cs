using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : HitObject
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _playerMovement.Move();
    }

    public override void Hit()
    {
        Debug.Log("Player Hit");
        _playerMovement.StopImmediately();
    }
}
