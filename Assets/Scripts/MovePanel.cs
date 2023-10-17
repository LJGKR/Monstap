using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePanel : MonoBehaviour
{
    public playerHealth playerhealth;
    public GameManager gm;
    public Button button;

    protected bool isMoving = false;

	void Update()
    {
        if((!gm.GameONOFF && !isMoving) || (gm.LimitTime <= 0 && !isMoving))
		{
            isMoving = true;
            movePanel();
            button.interactable = false;
        }
    }

    public void movePanel()
	{
        // iTween을 사용하여 패널을 targetPosition으로 올리는 애니메이션 생성
        iTween.MoveBy(gameObject, iTween.Hash("y", 700,
            "easetype", iTween.EaseType.linear));
    }
}
