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

    BoxCollider2D boxCol2D;
    float rayDistance = 0;
    LayerMask wallLayer;
    void Start()
    {
        Init();

        boxCol2D = GetComponent<BoxCollider2D>();
        rayDistance = boxCol2D.size.y * 0.5f + 0.01f;
        wallLayer = 1 << LayerMask.NameToLayer("Ground");
        Debug.Assert(wallLayer != 0, "레이어 지정안됨");
    }

    void Init()
    {
        gravityAcceleration = 9.81f;
        gravityVelocity = 0;
        s = 0;
    }

    RaycastHit2D ray;
    void Update()
    {
        if (IsGround() == false)
            gravityAccelerationMove();
        else
            Init();
    }

    private bool IsGround()
    {
        ray = Physics2D.Raycast(
                    transform.position, Vector2.down, rayDistance, wallLayer);
        return ray.transform;
    }
    
    private void gravityAccelerationMove()
    {
        gravityVelocity += gravityAcceleration * Time.deltaTime;

        s = gravityVelocity + (0.5f * gravityAcceleration * Mathf.Pow(Time.deltaTime, 2));

        transform.Translate(new Vector3(0, -s * Time.deltaTime, 0), Space.World);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rayDistance * Vector3.down);
    }
}