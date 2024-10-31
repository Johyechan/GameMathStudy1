using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondScene
{
    public class EnemyFOV : MonoBehaviour
    {
        public Vector3[] CalculateFOV(float radius, float angle)
        {
            Vector3[] results = new Vector3[2];

            float theta = 90 - angle - transform.eulerAngles.y;
            float x = Mathf.Cos(theta * Mathf.Deg2Rad) * radius;
            float y = transform.position.y;
            float z = Mathf.Sin(theta * Mathf.Deg2Rad) * radius;
            results[0] = new Vector3(x, y, z);

            theta = 90 + angle - transform.eulerAngles.y;
            x = Mathf.Cos(theta * Mathf.Deg2Rad) * radius;
            y = transform.position.y;
            z = Mathf.Sin(theta * Mathf.Deg2Rad) * radius;
            results[1] = new Vector3(x, y, z);

            return results;
        }

        //public bool CheckIsPlayerInFOV()
        //{

        //}
    }

}
