using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour
{
    public float enemyHP;
    private Rigidbody rd;
    public GameObject gm;

    private void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.useGravity = false; // 초기에 중력 비활성화
    }

    public void HpDown(float damage)
    {
        enemyHP -= damage;
        if (enemyHP <= 0) //죽음
        {
            rd.useGravity = !rd.useGravity;
        }
    }

    private void OnDestroy()
    {
        gm.GetComponent<ScoreManager>().currentScore += 1;
    }

    private void Update()
    {
        if (transform.position.y <= -3f)
        {
            Destroy(gameObject);
        }
    }
}

