using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMoving : MonoBehaviour
{
    int GolemDamage;
    //0번은 두리번, 1번은 움직임, 2번은 공격모션
    enum STATE { IDLE, MOVE, ATTACK };

    public Transform player;
    public float moveSpeed;
    public float stoppingDistance;
    public Animator animator;
    public playerHealth playerhealth;
    public CameraMoving playerCamera;

    //public event System.Action OnAttack;

    private Rigidbody rb;
    private Vector3 targetPosition;

    public GameManager gm;
    float ShakeAmount = 0.25f;

    private void Start()
    {
        //OnAttack += BeeAttackPlayer;

        rb = GetComponent<Rigidbody>();
        targetPosition = player.position; //몬스터 이동 위치를 저장함
        targetPosition.y = player.position.y - 0.5f;
        StartCoroutine("GolemMoveToPlayer");
    }

	private void Update()
	{
        GolemDamage = playerhealth.health;
    }

	IEnumerator GolemMoveToPlayer()
    {
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            Vector3 playerPosition = targetPosition;
            Vector3 monterPosition = transform.position;

            float distanceToPlayer = Vector3.Distance(playerPosition, monterPosition);

            Vector3 directionToPlayer = (playerPosition - monterPosition).normalized;

            if (distanceToPlayer > stoppingDistance)
            {
                Vector3 newPosition = rb.position + directionToPlayer * moveSpeed * Time.deltaTime;
                animator.SetInteger("State", (int)STATE.MOVE);

                rb.MovePosition(newPosition);
            }
            else
            {
                StopCoroutine("GolemMoveToPlayer");
                //OnAttack();
                GolemAttackPlayer();
                InvokeRepeating("DamageToPlayer", 1.5f, 2.7f);
            }

            yield return null;
        }
    }

    void GolemAttackPlayer()
    {
        animator.SetInteger("State", (int)STATE.ATTACK);
    }

    void DamageToPlayer()
    {
        if (playerhealth.health == GolemDamage)
        {
            playerCamera.VibrateForTime(ShakeAmount);
            playerhealth.health -= GolemDamage;
            Debug.Log("플레이어의 현재 체력 : " + playerhealth.health);
            Debug.Log("플레이어가 사망했습니다..");
            animator.SetInteger("State", (int)STATE.IDLE);
            gm.isTimerActive = false;
            gm.HeartCheck();
            ShakeAmount = 0;
        }
    }
}