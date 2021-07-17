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

    BoxCollider2D boxCol2D;
    float rayDistance = 0;
    LayerMask wallLayer;
    void Start()
    {
        Init();

        boxCol2D = GetComponent<BoxCollider2D>();
        rayDistance = boxCol2D.size.y * 0.5f + 0.01f;
        wallLayer = 1 << LayerMask.NameToLayer("Ground");
        Debug.Assert(wallLayer != 0, "���̾� �����ȵ�");
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