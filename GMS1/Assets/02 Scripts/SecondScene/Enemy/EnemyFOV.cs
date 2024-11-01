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
            // �켱 �츮�� �þ߰��� ���� ������ ������ ������ ���͸� ����� ����3 �迭�� �����.
            Vector3[] results = new Vector3[2];

            // �� 90������ ���°� 
            // ����Ƽ�� ��ǥ�迡�� forward ������ z������ ���ǰ� �ȴ�.
            // y���� ������ �ݿ��ϱ� ���ؼ��� 90�� ����� �Ѵ�.
            // �� 90�� ���ִ°� 
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
            // ������ �ʿ��� ���
            // ������ ������ Ȱ���Ͽ� �÷��̾���ġ������ ���͸� ���� �� ����ȭ�Ѵ�.
            // ����ȭ�� �ϴ� ������ �츮�� ���⸸ �ʿ��ϱ� �����̴�. (��? ���� �ȿ� ���� �ִ����� �˸� �Ǳ� ����)
            Vector3 playerVec = (_player.transform.position - transform.position).normalized;
            // �׷��ٸ� ������ �ϴ� ������ �����ΰ�
            // 1. ������ �ϴ� ������ �� ���Ͱ��� ������ �ڻ��� ������ ǥ���� �� �ֱ� �����̴�.
            // 2. ���� ����ȭ�� �� ��� ������ ���� a������ �ڻ��� ���� �������Ƿ� ������ ���� �Ǵ� �����ϴ�.

            // ������ ���⼭ ���� ���̸� �����ؾ��ϱ� ������ ����ȭ�� ���� ����ʹ� �޶�����.
            float dotResult = Vector3.Dot(transform.forward.normalized, playerVec);
            
            // �ڻ����� ����Ͽ� ���ϴ� ������ �ڻ����� ������ �ϴ� ������ 2���� ������ �ִ�.
            // �ᱹ ������ ����ȭ�� �ؼ� ������ ��� a������ �ڻ��� ���� ������ �ȴ�.
            // �׷��⿡ �ڻ������� ���ϴ� ���̴�.
            float threshold = Mathf.Cos(angle * Mathf.Deg2Rad);

            // �� ������ ���� �� Ŀ���ϴ°�?
            // ���÷� �츮�� ����, ���������� ���� 45�� �� ������ �� 90������ �þ߰��� �����ٰ� �����غ���
            // �׷��� �Ǹ� ���� �ڽ��� forward ���͸� ������ ���� �׳� �ڻ��� 45������ ũ�� �ȴ�.
            // �� Ŀ���ϳ�?
            // �ڻ����� ������ 0 = 1, 90 = 0, 180 = -1 �̱� �����̴�.
            // �׷��� �ڻ��� 45�� = 0.707 �̶�� �ϸ� �ڻ��� 30�� = 0.866������ ���´�.
            // �� ���ذ� �ȵȴٸ� �׷����� ã�ƺ��� �ξ� ���ذ� �� �� ���̴�.
            // �׸��� �� �ǹ��� �� �� �ִ�.
            // �ƴ� �����̶� ������ ���� 45�� �� �������µ� �� �� ������ ���� ���� �ڻ��� 45�� ���� ũ�⸸ �ϸ� �ǳ���?
            // ������ �߿��� ���� forward���Ϳ� �÷��̾���� ������ ������ ���� ���̶�� ���̴�.
            // ���ø� �� �츮�� ���밡 �ִ�.
            // �� ���븦 �������� ���������� 45�� ������ ������ �������� 45�� ������ ������ ���� �Ȱ��� 45���̴�.
            // �׷��⿡ �þ߰��� �Ǻ��� �� �ڻ��� 45������ ū���� Ȯ���ϸ� �ȴ�.
            // ������ �� ���⼭ �þ߰��� �Ǻ��� �� ���̵� �����ϱ� ���ؼ� ���̸� ���� �����ְڴ�
            return dotResult >= threshold;
        }
    }

}
