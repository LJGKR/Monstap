using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpawner : MonoBehaviour
{
    public GameObject Tornado;
    public GameObject camPosition;

    public void castTornado()
    {
        // 저장된 회전 값을 기반으로 회전된 방향을 구합니다.
        Vector3 direction = camPosition.transform.rotation * Vector3.forward;

        // 새로운 오브젝트의 생성 위치를 계산합니다.
        Vector3 createPos = camPosition.transform.position + direction * 1.0f - Vector3.up * 0.7f;

        // 오브젝트를 생성합니다.
        GameObject tornado = Instantiate(Tornado, createPos, camPosition.transform.rotation);
        tornado.SetActive(true);
    }
}
