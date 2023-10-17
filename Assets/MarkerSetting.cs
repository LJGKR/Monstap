using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerSetting : MonoBehaviour
{
    public Transform parentObject; // 부모 오브젝트를 여기에 연결
    public bool followYRotation = true; // Y축 회전 따라가기 여부

    private void Update()
    {
        if (parentObject != null)
        {
            // 부모 오브젝트의 회전 변화를 가져옴
            Quaternion parentRotation = parentObject.rotation;

            // Y축 회전만 적용
            Quaternion newRotation = followYRotation
                ? Quaternion.Euler(0, parentRotation.eulerAngles.y, 0)
                : parentRotation;

            // 자식 오브젝트의 회전을 적용
            transform.rotation = newRotation;
        }
    }
}
