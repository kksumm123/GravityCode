using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAcceleration : MonoBehaviour
{
    // 속도값 선언하고
    // 가속도만큼 더해진다
    // 거리만큼 이동
    // t = 시간, g = 중력가속도
    // v = 속도, s = 이동거리,
    // 낙하 속도 v1 = v0 + gt
    // 낙하 시간 s = v0 + (0.5 * g * t^2)

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