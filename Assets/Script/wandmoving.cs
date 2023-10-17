using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandmoving : MonoBehaviour
{
    public ParticleSystem chargeParticle;
    public GameObject Magic;
    // target ���� ������Ʈ�� ParticleGo ������Ʈ ��������

    /*��� ó���� ���� �Լ� ���� ������*/
    public float radius;        // ���� ��
    public float circlerotation_Spd_s; // ���� ���� �ӵ� (�� ����)
    public float totalRevolutions; // �� �� ���� �� ������

    private Transform thisTransform;
    private Vector3 centerPosition;
    private float currentAngle = 0.0f;
    private bool isRotating = false;

    private Transform parentTransform;
    /// ///////////////////////////////////////////////////////////

    /*z��������� Ư��������ŭ �Դ� �����ϴ� �Լ� ���� ������*/
    public float targetAngle;    // Ŭ�� �� ������ ����
    public float snap_Spd_s;  // ȸ�� �ӵ� (�� ����)
    public float return_Spd_s;    // ���� �ӵ� (�� ����)

    private Vector3 originalPosition;
    private bool isMoving = false;
    /// ////////////////////////////////////////////////////////////////
    private void Start()
    {
        thisTransform = transform;
        centerPosition = thisTransform.position + new Vector3(0, 0.1f, 0); // y������ 0.1��ŭ ���� �ִ� ��ǥ

        originalPosition = thisTransform.position;
        parentTransform = transform.parent; // �θ� ������Ʈ�� Transform�� ������
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

            // ������ �������� ��ȯ�Ͽ� �� ���� ��ġ�� ���
            //Vector3 positionOffset = Quaternion.Euler(0, currentAngle, 0) * (Vector3.forward * wheelCount);
            Vector3 positionOffset = Quaternion.Euler(0, 0, currentAngle) * (Vector3.up * radius);

            //// �߽� ��ǥ�� �����־� ��� ��ġ�� ���ϴ� �߽����� �̵�
            //thisTransform.position = centerPosition + positionOffset;
            // ����: �θ� ������Ʈ�� �������� �ݿ��Ͽ� ��ġ ������Ʈ
            thisTransform.localPosition = centerPosition + positionOffset + parentTransform.localPosition;


            yield return null; // ���� �����ӱ��� ���
        }

        currentAngle = 0.0f;
        isRotating = false;
        Magic.GetComponent<MagicSpawner>().castTornado();
        StartCoroutine(MoveAndReturn());
    }

    private IEnumerator MoveAndReturn()
    {
        float currentAngle = 0.0f;

        // Ŭ�� �� ������ŭ ȸ��
        while (currentAngle < targetAngle)
        {
            currentAngle += snap_Spd_s * Time.deltaTime;
            thisTransform.Rotate(Vector3.right, snap_Spd_s * Time.deltaTime);

            yield return null;
        }

        // Ŭ�� �� ����ġ�� ���ƿ�
        while (currentAngle > 0.0f)
        {
            currentAngle -= return_Spd_s * Time.deltaTime;
            thisTransform.Rotate(Vector3.left, return_Spd_s * Time.deltaTime);

            yield return null;
        }

        // ȸ�� ���� ����
        thisTransform.Rotate(Vector3.left, currentAngle);
        isMoving = false;
    }
}
