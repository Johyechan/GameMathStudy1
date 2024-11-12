using FirstScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondScene
{
    public class Enemy : MonoBehaviour
    {
        private EnemyFOV _fov;

        [SerializeField] private float _Distance;
        [SerializeField] private float _Degree;

        private bool _isStart = false;

        private void Awake()
        {
            _fov = GetComponent<EnemyFOV>();
        }

        private void Start()
        {
            _isStart = true;
        }

        private void Update()
        {
            if(_fov.CheckIsPlayerInFOV(_Distance, _Degree))
            {
                Debug.Log("시야각 안에 들어옴");
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            if(!_isStart)
            {
                return;
            }

            if (_Distance != 0 && _Degree != 0)
            {
                Vector3[] lineVectors = _fov.CalculateFOV(_Distance, _Degree);

                for (int i = 0; i < lineVectors.Length; i++)
                {
                    Gizmos.DrawLine(transform.position, transform.position + lineVectors[i]);
                }
            }
        }
    }
}

