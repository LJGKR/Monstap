using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameONOFF;

    public Slider sliderTimer;
    public Text timeText;
    public float LimitTime = 60; //제한시간 60초
    public bool isTimerActive = true;
	public AudioSource audioSource;
	public AudioSource audioSource2;

	public GameObject[] imageObj;
    public Image[] myImage;
    public Sprite[] Heart;

    public GameObject PauseUI;
    public GameObject ClickPauseUI;
    public playerHealth playerhealth;
    private bool paused = false;

	private void Start()
	{
		audioSource.Play();
        GameONOFF = true;
        PauseUI.SetActive(false);
        ClickPauseUI.SetActive(true);

        for (int i=0; i<5; i++)
		{
            imageObj[i] = GameObject.FindGameObjectWithTag("Heart" + i);
            myImage[i] = imageObj[i].GetComponent<Image>();
        }
    }
	void Update()
    {
        if(LimitTime > 0 && sliderTimer.value >0.0f && isTimerActive)
		{
            LimitTime -= Time.deltaTime;
            sliderTimer.value -= Time.deltaTime;
            timeText.text = "" + Mathf.Round(LimitTime);
        }

        if(paused)
		{
            PauseUI.SetActive(true);
            ClickPauseUI.SetActive(false);
            Time.timeScale = 0;
		}
        if(!paused)
		{
            PauseUI.SetActive(false);
            ClickPauseUI.SetActive(true);
            Time.timeScale = 1f;
		}

        if(playerhealth.health <= 0)
        {
            GameONOFF = false;
        }
    }


    public void activePause()
	{
        paused = !paused;
	}

    public void HeartCheck()
    {
        if (playerhealth.health > 0)
        {
            int hpCount = playerhealth.health / 20;
            for (int i = 1; i <= hpCount; i++)
            {
                myImage[i - 1].sprite = Heart[0];
            }
            for (int i = 5; i > hpCount; i--)
            {
                myImage[i - 1].sprite = Heart[1];
            }
        }
        else
        {
            for (int i = 5; i > 0; i--)
            {
                myImage[i - 1].sprite = Heart[1];
            }
        }
    }

    public void StartUiSound()
    {
        audioSource2.Play();

	}
}
