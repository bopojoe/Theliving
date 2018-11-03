using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startButton()
	{
		SceneManager.LoadScene(3);
	}

	public void optionsButton()
	{
		SceneManager.LoadScene(2);
	}

	public void retryButton()
	{
		startButton();
	}
	
	public void menuButton()
	{
		SceneManager.LoadScene(1);
	}
}
