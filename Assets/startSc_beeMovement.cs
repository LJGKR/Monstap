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

    public Transform target;  // 움직일 대상 오브젝트
    public float moveSpeed = 5.0f;  // 움직이는 속도

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
                        // 타겟 방향으로 향하는 벡터 계산
                        Vector3 direction = (target.position - transform.position).normalized;

                        // 움직일 거리 계산
                        float distance = moveSpeed * Time.deltaTime;

                        // 현재 위치에서 타겟 방향으로 일정 거리만큼 움직임
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

                            hasMoved = true; // 코드가 한 번 실행되었음을 표시
                        }
                    }

                }
            }
            else
            {
                if(gameObject.transform.position.z >= 0.7) { 
                }
                Vector3 newPosition = golemhand.transform.position; // 현재 위치를 golemhand 위치로 설정
                newPosition += golemhand.transform.up * 0.1f; // golemhand의 up 방향을 기준으로 0.3만큼 띄우기
                gameObject.transform.position = newPosition; // 새로운 위치로 이동
            }
        }
    }
}
