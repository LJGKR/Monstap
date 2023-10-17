using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerSetting : MonoBehaviour
{
    public Transform parentObject; // �θ� ������Ʈ�� ���⿡ ����
    public bool followYRotation = true; // Y�� ȸ�� ���󰡱� ����

    private void Update()
    {
        if (parentObject != null)
        {
            // �θ� ������Ʈ�� ȸ�� ��ȭ�� ������
            Quaternion parentRotation = parentObject.rotation;

            // Y�� ȸ���� ����
            Quaternion newRotation = followYRotation
                ? Quaternion.Euler(0, parentRotation.eulerAngles.y, 0)
                : parentRotation;

            // �ڽ� ������Ʈ�� ȸ���� ����
            transform.rotation = newRotation;
        }
    }
}
