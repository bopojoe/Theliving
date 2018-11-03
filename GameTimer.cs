using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	private  float gameTimer;
	public Text show;
	private int minTimer;
	
	
	
	// Use this for initialization
	void Start ()
	{
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameTimer += Time.deltaTime % 60;
		if (gameTimer >= 59.9)
		{
			gameTimer = 0;
			minTimer++;
		}
		
		
		show.text = minTimer+" mins "+ gameTimer.ToString("F2") + " seconds";
		
	}
}
