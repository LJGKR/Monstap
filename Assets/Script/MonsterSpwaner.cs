using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpwaner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform campos;
    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        CreateMonster(prefabs[0], campos);
    }

    private float timer = 0f;
    public float interval = 3f; // 실행 간격 (초 단위)

    private void Update()
    {
        if (gm.GameONOFF)
        {
            // 매 프레임마다 타이머를 증가시킴
            timer += Time.deltaTime;

            // 타이머가 실행 간격을 초과하면 함수 실행 후 타이머 리셋
            if (timer >= interval)
            {
                ExecuteFunction(); // 실행할 함수 호출
                timer = 0f; // 타이머 리셋
                if (interval >= 1.6f)
                {
                    interval -= 0.1f;
                }
            }
        }
    }

    private void ExecuteFunction()
    {
        CreateMonster(prefabs[0], campos);
    }

    void CreateMonster(GameObject preFab, Transform camPos)
    {
        //구형태의 랜덤한 각도의 일정한 벡터를 구하는 함수;
        Vector3 position = GetRandomPointOnSphere(8.0f, -180.0f, 180.0f, -5.0f, 45.0f);

        //기본값 Quaternion
        Quaternion rotation = GetLookAtRotation(camPos.position, position);

        GameObject myInstance = Instantiate(preFab, position, rotation, camPos);
        

        // 오브젝트를 월드상에 보이도록 설정
        myInstance.SetActive(true);
    }

    public Vector3 GetRandomPointOnSphere(float radius, float minVerticalAngle, float maxVerticalAngle, float minHorizontalAngle, float maxHorizontalAngle)
    {   
        float verticalAngle = Random.Range(minVerticalAngle, maxVerticalAngle);
        float horizontalAngle = Random.Range(minHorizontalAngle, maxHorizontalAngle);

        float x = radius * Mathf.Sin(Mathf.Deg2Rad * verticalAngle) * Mathf.Cos(Mathf.Deg2Rad * horizontalAngle);
        float y = radius * Mathf.Sin(Mathf.Deg2Rad * verticalAngle) * Mathf.Sin(Mathf.Deg2Rad * horizontalAngle);
        float z = radius * Mathf.Cos(Mathf.Deg2Rad * verticalAngle);

        return new Vector3(x, y, z);
    }

    public Quaternion GetLookAtRotation(Vector3 targetPosition, Vector3 sourcePosition)
    {
        // 두 Transform 사이의 방향 벡터를 구합니다.
        Vector3 directionToTarget = targetPosition - sourcePosition;

        // 방향 벡터를 기반으로 회전 값을 계산합니다.
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

        return lookRotation;
    }
}
