using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandmoving : MonoBehaviour
{
    public ParticleSystem chargeParticle;
    public GameObject Magic;
    // target 게임 오브젝트의 ParticleGo 컴포넌트 가져오기

    /*원운동 처리를 위한 함수 관리 변수들*/
    public float radius;        // 바퀴 수
    public float circlerotation_Spd_s; // 바퀴 도는 속도 (도 단위)
    public float totalRevolutions; // 총 몇 바퀴 돌 것인지

    private Transform thisTransform;
    private Vector3 centerPosition;
    private float currentAngle = 0.0f;
    private bool isRotating = false;

    private Transform parentTransform;
    /// ///////////////////////////////////////////////////////////

    /*z축방향으로 특정각도만큼 왔다 갔다하는 함수 관리 변수들*/
    public float targetAngle;    // 클릭 시 움직일 각도
    public float snap_Spd_s;  // 회전 속도 (도 단위)
    public float return_Spd_s;    // 복귀 속도 (도 단위)

    private Vector3 originalPosition;
    private bool isMoving = false;
    /// ////////////////////////////////////////////////////////////////
    private void Start()
    {
        thisTransform = transform;
        centerPosition = thisTransform.position + new Vector3(0, 0.1f, 0); // y값으로 0.1만큼 위에 있는 좌표

        originalPosition = thisTransform.position;
        parentTransform = transform.parent; // 부모 오브젝트의 Transform을 가져옴
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating)
        {
            isRotating = true;
            StartCoroutine(PerformCircularMotion());

        }
        if (Input.GetMouseButtonDown(1) && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveAndReturn());
        }
    }

    private IEnumerator PerformCircularMotion()
    {
        chargeParticle.Play();
        float targetAngle = currentAngle + 360.0f * totalRevolutions;

        while (currentAngle < targetAngle)
        {
            currentAngle += circlerotation_Spd_s * Time.deltaTime;

            // 각도를 라디안으로 변환하여 원 위의 위치를 계산
            //Vector3 positionOffset = Quaternion.Euler(0, currentAngle, 0) * (Vector3.forward * wheelCount);
            Vector3 positionOffset = Quaternion.Euler(0, 0, currentAngle) * (Vector3.up * radius);

            //// 중심 좌표를 더해주어 원운동 위치를 원하는 중심으로 이동
            //thisTransform.position = centerPosition + positionOffset;
            // 수정: 부모 오브젝트의 움직임을 반영하여 위치 업데이트
            thisTransform.localPosition = centerPosition + positionOffset + parentTransform.localPosition;


            yield return null; // 다음 프레임까지 대기
        }

        currentAngle = 0.0f;
        isRotating = false;
        Magic.GetComponent<MagicSpawner>().castTornado();
        StartCoroutine(MoveAndReturn());
    }

    private IEnumerator MoveAndReturn()
    {
        float currentAngle = 0.0f;

        // 클릭 시 각도만큼 회전
        while (currentAngle < targetAngle)
        {
            currentAngle += snap_Spd_s * Time.deltaTime;
            thisTransform.Rotate(Vector3.right, snap_Spd_s * Time.deltaTime);

            yield return null;
        }

        // 클릭 후 원위치로 돌아옴
        while (currentAngle > 0.0f)
        {
            currentAngle -= return_Spd_s * Time.deltaTime;
            thisTransform.Rotate(Vector3.left, return_Spd_s * Time.deltaTime);

            yield return null;
        }

        // 회전 각도 보정
        thisTransform.Rotate(Vector3.left, currentAngle);
        isMoving = false;
    }
}
