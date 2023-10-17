using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;

    private int startinghighscore;

    public Text highscoreText;
    public Text lastScore;

    void Start()
    {
        startinghighscore = PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        UpdateHighScore();
        savescore();
    }

    public void UpdateHighScore()
	{
       if (currentScore > startinghighscore)
       {
            PlayerPrefs.SetInt("highscore", currentScore);
       }

        PlayerPrefs.SetInt("lastscore", currentScore);
    }

    void savescore()
    {
        if (highscoreText != null)
        {
            highscoreText.text = $"Best Score\n{PlayerPrefs.GetInt("highscore").ToString()}";
        }

        if (lastScore != null)
        {
            lastScore.text = $"Score\n{PlayerPrefs.GetInt("lastscore").ToString()}\nCONTINUE?";
        }
    }
}
