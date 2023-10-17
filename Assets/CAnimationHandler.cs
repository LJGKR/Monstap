using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimationHandler : MonoBehaviour
{
    #region Fields
    #endregion Fields

    #region Members
    private Animator m_Animator;
    public bool AnimationCheck;
    public bool AnimationCheck2;
    #endregion Members


    #region Methods
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        AnimationCheck = false;
        AnimationCheck2 = false;
    }

    public void EventStart()
    {
        Debug.Log("�̺�Ʈ����");
        m_Animator.SetBool("Once", true);
    }
    public void EventEnd()
    {
        Debug.Log("�̺�Ʈ��");
        AnimationCheck = true;
    }

    public void Eventhalf()
    {
        Debug.Log("�̺�Ʈ�߰�");
        AnimationCheck2 = true;
    }

    #endregion Methods
}
