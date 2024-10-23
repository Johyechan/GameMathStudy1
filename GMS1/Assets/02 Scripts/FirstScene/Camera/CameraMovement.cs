using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : Movement
{
    [SerializeField] private Vector3 _DistanceVector;

    private GameObject _playerObject;
    private GameObject _camera;

    private void Start()
    {
        _playerObject = GameObject.Find("Player");
        _camera = Camera.main.gameObject;
    }

    public override void Move()
    {
        Vector3 playerPos = _playerObject.transform.position;

        Vector3 sumVector = playerPos + _DistanceVector;

        Vector3 cameraPos = new Vector3(sumVector.x, _camera.transform.position.y, sumVector.z);

        _camera.transform.position = Vector3.Lerp(_camera.transform.position, cameraPos, _Speed * Time.deltaTime);
    }
}
