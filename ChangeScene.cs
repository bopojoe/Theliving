using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public GameObject source1;
	public GameObject source2;
	public AudioClip clip;
	

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startButton()
	{
	
		
		//source1.GetComponent<AudioSource>().Play();
		

			SceneManager.LoadScene(3);
		
	}

	public void optionsButton()
	{

		source1.GetComponent<AudioSource>().PlayOneShot(clip, 1.25f);
		SceneManager.LoadScene(2);
	}

	public void retryButton()
	{
		//source2.Play();
		startButton();
	}
	
	public void menuButton()
	{
		//source2.Play();
		SceneManager.LoadScene(1);
	}

	void waitTime(int num)
	{
		int count = num;
		float timer = Time.deltaTime;
		while (count > 0)
		{
			num -= (int) timer % 60;
			
		}
	}
}
