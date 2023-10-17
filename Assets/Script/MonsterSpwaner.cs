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
    public float interval = 3f; // ���� ���� (�� ����)

    private void Update()
    {
        if (gm.GameONOFF)
        {
            // �� �����Ӹ��� Ÿ�̸Ӹ� ������Ŵ
            timer += Time.deltaTime;

            // Ÿ�̸Ӱ� ���� ������ �ʰ��ϸ� �Լ� ���� �� Ÿ�̸� ����
            if (timer >= interval)
            {
                ExecuteFunction(); // ������ �Լ� ȣ��
                timer = 0f; // Ÿ�̸� ����
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
        //�������� ������ ������ ������ ���͸� ���ϴ� �Լ�;
        Vector3 position = GetRandomPointOnSphere(8.0f, -180.0f, 180.0f, -5.0f, 45.0f);

        //�⺻�� Quaternion
        Quaternion rotation = GetLookAtRotation(camPos.position, position);

        GameObject myInstance = Instantiate(preFab, position, rotation, camPos);
        

        // ������Ʈ�� ����� ���̵��� ����
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
        // �� Transform ������ ���� ���͸� ���մϴ�.
        Vector3 directionToTarget = targetPosition - sourcePosition;

        // ���� ���͸� ������� ȸ�� ���� ����մϴ�.
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

        return lookRotation;
    }
}
