using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAcceleration : MonoBehaviour
{
    // �ӵ��� �����ϰ�
    // ���ӵ���ŭ ��������
    // �Ÿ���ŭ �̵�
    // t = �ð�, g = �߷°��ӵ�
    // v = �ӵ�, s = �̵��Ÿ�,
    // ���� �ӵ� v1 = v0 + gt
    // ���� �ð� s = v0 + (0.5 * g * t^2)

    [SerializeField] float gravityAcceleration = 9.81f;
    [SerializeField] float gravityVelocity;
    [SerializeField] float s;

    void Start()
    {
        gravityAcceleration = 9.81f;
        gravityVelocity = 0;
        s = 0;
    }

    void Update()
    {
        gravityVelocity += gravityAcceleration * Time.deltaTime;

        s = gravityVelocity + (0.5f * gravityAcceleration * Mathf.Pow(Time.deltaTime, 2));

        transform.Translate(new Vector3(0, -s * Time.deltaTime, 0), Space.World);
    }
}