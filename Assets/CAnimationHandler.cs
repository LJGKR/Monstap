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
        Debug.Log("이벤트시작");
        m_Animator.SetBool("Once", true);
    }
    public void EventEnd()
    {
        Debug.Log("이벤트끝");
        AnimationCheck = true;
    }

    public void Eventhalf()
    {
        Debug.Log("이벤트중간");
        AnimationCheck2 = true;
    }

    #endregion Methods
}
