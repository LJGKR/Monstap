using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMoving : MonoBehaviour
{
    const int beeDamage = 20;
    //0���� �θ���, 1���� ������, 2���� ���ݸ��
    enum STATE { IDLE, MOVE, ATTACK };

    public Transform player;
    public float moveSpeed;
    public float stoppingDistance;
    public Animator animator;
    public playerHealth playerhealth;
    public CameraMoving playerCamera;
    public GameManager gm;

    float ShakeAmount = 0.2f;


    //public event System.Action OnAttack;

    private Rigidbody rb;
    private Vector3 targetPosition;

    private void Start()
    {
        //OnAttack += BeeAttackPlayer;

        rb = GetComponent<Rigidbody>();
        targetPosition = player.position; //���� �̵� ��ġ�� ������
        targetPosition.y = player.position.y - 0.5f;
        StartCoroutine("BeeMoveToPlayer");
    }

    IEnumerator BeeMoveToPlayer()
    {
        yield return new WaitForSeconds(2.0f);

        while(true)
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
                StopCoroutine("BeeMoveToPlayer");
                //OnAttack();
                BeeAttackPlayer();
                InvokeRepeating("DamageToPlayer",0.8f,2.05f);
            }

            yield return null;
        }
    }

    void BeeAttackPlayer()
    {
        animator.SetInteger("State", (int)STATE.ATTACK);
    }

    void DamageToPlayer()
    {
        if (playerhealth.health > 0)
        {
            playerCamera.VibrateForTime(ShakeAmount);
            playerhealth.health -= beeDamage;
            Debug.Log("�÷��̾��� ���� ü�� : " + playerhealth.health);
            gm.HeartCheck();
        }
        else if (playerhealth.health <= 0)
        {
            playerCamera.VibrateForTime(ShakeAmount);
            playerhealth.health -= beeDamage;
            Debug.Log("�÷��̾��� ���� ü�� : " + playerhealth.health);
            Debug.Log("�÷��̾ ����߽��ϴ�..");
            animator.SetInteger("State", (int)STATE.IDLE);
            gm.isTimerActive = false;
            gm.HeartCheck();
            gm.ClickPauseUI.SetActive(false);
            ShakeAmount = 0;
            CancelInvoke("DamageToPlayer");
        }
    }
}