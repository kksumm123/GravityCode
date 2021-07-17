using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAcceleration : MonoBehaviour
{
    // �ӵ��� �����ϰ�
    // ���ӵ���ŭ ��������
    // �ӵ���ŭ pos -
    // t = �ð�, g = �߷°��ӵ�
    // v = �ӵ�, s = �̵��Ÿ�,
    // ���� �ӵ� v1 = v0 + gt
    // ���� �ð� s = (v0 * t) + (0.5 * g * t^2)

    [SerializeField] float gravityAcceleration = 9.81f;
    [SerializeField] float gravityVelocity;
    [SerializeField] float s;
    void Start()
    {
        gravityAcceleration = 9.81f;
        gravityVelocity = 0;
        s = 0;
    }

    Vector3 pos;
    void Update()
    {
        gravityVelocity += gravityAcceleration * Time.fixedDeltaTime;
        
        s = (gravityVelocity * Time.fixedDeltaTime)
            + (0.5f * gravityAcceleration * Mathf.Pow(Time.fixedDeltaTime, 2));

        transform.Translate(new Vector3(0, -s, 0), Space.World);
    }
}