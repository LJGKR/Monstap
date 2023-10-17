using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	public void loadAnotherScene()
    {
		SceneManager.LoadScene("SampleScene");
	}
}
