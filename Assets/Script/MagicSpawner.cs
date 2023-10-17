using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpawner : MonoBehaviour
{
    public GameObject Tornado;
    public GameObject camPosition;

    public void castTornado()
    {
        // ����� ȸ�� ���� ������� ȸ���� ������ ���մϴ�.
        Vector3 direction = camPosition.transform.rotation * Vector3.forward;

        // ���ο� ������Ʈ�� ���� ��ġ�� ����մϴ�.
        Vector3 createPos = camPosition.transform.position + direction * 1.0f - Vector3.up * 0.7f;

        // ������Ʈ�� �����մϴ�.
        GameObject tornado = Instantiate(Tornado, createPos, camPosition.transform.rotation);
        tornado.SetActive(true);
    }
}
