using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecondScene
{
    public class EnemyFOV : MonoBehaviour
    {
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.Find("Player");
        }

        public Vector3[] CalculateFOV(float radius, float angle)
        {
            // 우선 우리의 시야각의 왼쪽 끝점과 오른쪽 끝점의 벡터를 담아줄 벡터3 배열을 만든다.
            Vector3[] results = new Vector3[2];

            // 왜 90도에서 빼는가 
            // 유니티의 좌표계에서 forward 방향이 z축으로 정의가 된다.
            // y축의 각도를 반영하기 위해서는 90을 빼줘야 한다.
            // 왜 90을 빼주는가 
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

        public bool CheckIsPlayerInFOV(float angle)
        {
            // 각도만 필요한 경우
            // 벡터의 뺄셈을 활용하여 플레이어위치까지의 벡터를 구한 후 정규화한다.
            // 정규화를 하는 이유는 우리가 방향만 필요하기 때문이다. (왜? 각도 안에 들어와 있는지만 알면 되기 때문)
            Vector3 playerVec = (_player.transform.position - transform.position).normalized;
            // 그렇다면 내적을 하는 이유는 무엇인가
            // 1. 내적을 하는 이유는 두 벡터간의 각도를 코사인 값으로 표현할 수 있기 때문이다.
            // 2. 또한 정규화를 한 경우 내적한 값이 a각도의 코사인 값과 같아지므로 각도를 쉽게 판단 가능하다.

            // 하지만 여기서 나는 길이를 생각해야하기 때문에 정규화한 값의 결과와는 달라진다.
            float dotResult = Vector3.Dot(transform.forward.normalized, playerVec);
            
            // 코사인을 사용하여 구하는 이유는 코사인은 내적을 하는 이유의 2번과 관련이 있다.
            // 결국 내적도 정규화를 해서 내적할 경우 a각도의 코사인 값이 나오게 된다.
            // 그렇기에 코사인으로 비교하는 것이다.
            float threshold = Mathf.Cos(angle * Mathf.Deg2Rad);

            // 왜 내적한 값이 더 커야하는가?
            // 예시로 우리가 왼쪽, 오른쪽으로 각각 45도 씩 벌어진 총 90각도의 시야각을 가진다고 생각해보자
            // 그렇게 되면 대상과 자신의 forward 벡터를 내적한 값이 그냥 코사인 45값보다 크면 된다.
            // 왜 커야하냐?
            // 코사인은 각도가 0 = 1, 90 = 0, 180 = -1 이기 때문이다.
            // 그래서 코사인 45도 = 0.707 이라고 하면 코사인 30도 = 0.866정도가 나온다.
            // 잘 이해가 안된다면 그래프를 찾아보면 훨씬 이해가 잘 될 것이다.
            // 그리고 또 의문이 들 수 있다.
            // 아니 왼쪽이랑 오른쪽 각각 45도 씩 벌어졌는데 왜 두 벡터의 내적 값이 코사인 45도 보다 크기만 하면 되나요?
            // 하지만 중요한 것은 forward벡터와 플레이어방향 벡터의 각도를 보는 것이라는 것이다.
            // 예시를 들어서 우리가 막대가 있다.
            // 그 막대를 기준으로 오른쪽으로 45도 기울어진 각도와 왼쪽으로 45도 기울어진 각도는 둘이 똑같이 45도이다.
            // 그렇기에 시야각을 판별할 때 코사인 45도보다 큰지만 확인하면 된다.
            // 하지만 난 여기서 시야각을 판별할 때 길이도 생각하기 위해서 길이를 각각 곱해주겠다
            return dotResult >= threshold;
        }
    }

}
