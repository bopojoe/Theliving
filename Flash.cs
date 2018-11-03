using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flash : MonoBehaviour
{

	private float timer;
	private float timer2 = 0;
	public GameObject text;
	private bool toggle;

	

	// Use this for initialization
	void Start()
	{



	}

	// Update is called once per frame
	void Update()
	{

		{
			timer += Time.deltaTime;
			timer2 = timer % 60;
			//print("seconds: "+ timer2+", "+"timer: "+timer);
			if (timer2 > 1)
			{
				text.SetActive(toggle);
				timer = 0;
				toggle = !toggle;
			}
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			print("enter key pressed");
			SceneManager.LoadScene(1);
		}

	}
}