using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    public GameObject Tornado; // Ǯ���� ������
    public int initialPoolSize_Tornado = 6; // �ʱ� Ǯ ������

    private List<GameObject> pool = new List<GameObject>(); // ������Ʈ Ǯ

    private void Awake()
    {
        // �ʱ⿡ Ǯ���� ������Ʈ ����
        for (int i = 0; i < initialPoolSize_Tornado; i++)
        {
            GameObject newObj = Instantiate(Tornado);
            newObj.SetActive(false);
            pool.Add(newObj);
        }
    }

    public GameObject GetObject_Tonado()
    {
        // ��Ȱ��ȭ�� ������Ʈ�� ã�� ��ȯ�ϰų�, ���ٸ� ���� �����ؼ� ��ȯ
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Ǯ�� �� �ڸ��� ������ �� ������Ʈ �����ؼ� ��ȯ
        GameObject newObj = Instantiate(Tornado);
        pool.Add(newObj);
        return newObj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // ������Ʈ�� ��Ȱ��ȭ�ϰ� �ʱ� ���·� ����
        obj.SetActive(false);
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;
    }
}
