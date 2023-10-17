using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void changeSplashScene()
	{
		SceneManager.LoadScene("StartScene");
	}

	public void GameExit()
	{
		Application.Quit();
	}
}
