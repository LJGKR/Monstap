using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSc_beeMovement : MonoBehaviour
{
    public GameObject golem;
    public GameObject golemhand;
    public GameObject cam;

    public ParticleSystem particle1;
    public ParticleSystem particle2;
    private ParticleSystem.MainModule mainModule;

    public GameObject cv;
    public AudioSource audioSource;

    public Transform target;  // ������ ��� ������Ʈ
    public float moveSpeed = 5.0f;  // �����̴� �ӵ�

    private bool hasMoved;

    // Start is called before the first frame update
    void Start()
    {
        hasMoved = false;
        mainModule = particle1.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (golem.GetComponent<CAnimationHandler>().AnimationCheck2)
        {
            if (golem.GetComponent<CAnimationHandler>().AnimationCheck)
            {
                if (target != null)
                {
                    if (gameObject.transform.position.z >= 0.7)
                    {
                        // Ÿ�� �������� ���ϴ� ���� ���
                        Vector3 direction = (target.position - transform.position).normalized;

                        // ������ �Ÿ� ���
                        float distance = moveSpeed * Time.deltaTime;

                        // ���� ��ġ���� Ÿ�� �������� ���� �Ÿ���ŭ ������
                        transform.position += direction * distance;
                    }
                    else
                    {
                        gameObject.GetComponent<Rigidbody>().useGravity = true;

                        if (particle1.time >= mainModule.duration)
                        {
                            cv.SetActive(true);
                        }

                        if (!hasMoved)
                        {
                            particle1.Play();
                            particle2.Play();
                            audioSource.Play();

                            hasMoved = true; // �ڵ尡 �� �� ����Ǿ����� ǥ��
                        }
                    }

                }
            }
            else
            {
                if(gameObject.transform.position.z >= 0.7) { 
                }
                Vector3 newPosition = golemhand.transform.position; // ���� ��ġ�� golemhand ��ġ�� ����
                newPosition += golemhand.transform.up * 0.1f; // golemhand�� up ������ �������� 0.3��ŭ ����
                gameObject.transform.position = newPosition; // ���ο� ��ġ�� �̵�
            }
        }
    }
}
