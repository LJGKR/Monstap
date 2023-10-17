using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    public GameObject Tornado; // 풀링할 프리팹
    public int initialPoolSize_Tornado = 6; // 초기 풀 사이즈

    private List<GameObject> pool = new List<GameObject>(); // 오브젝트 풀

    private void Awake()
    {
        // 초기에 풀링할 오브젝트 생성
        for (int i = 0; i < initialPoolSize_Tornado; i++)
        {
            GameObject newObj = Instantiate(Tornado);
            newObj.SetActive(false);
            pool.Add(newObj);
        }
    }

    public GameObject GetObject_Tonado()
    {
        // 비활성화된 오브젝트를 찾아 반환하거나, 없다면 새로 생성해서 반환
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // 풀에 빈 자리가 없으면 새 오브젝트 생성해서 반환
        GameObject newObj = Instantiate(Tornado);
        pool.Add(newObj);
        return newObj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // 오브젝트를 비활성화하고 초기 상태로 리셋
        obj.SetActive(false);
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;
    }
}
