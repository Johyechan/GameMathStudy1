using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstScene
{
    public class CameraManager : MonoBehaviour
    {
        private CameraMovement _cameraMovement;

        private void Awake()
        {
            _cameraMovement = GetComponent<CameraMovement>();
        }

        void Update()
        {
            _cameraMovement.Move();
        }
    }
}

