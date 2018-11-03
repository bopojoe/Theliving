using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class loadPlayerPrefs : MonoBehaviour
{
	public Text result;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Awake()
	{
		Screen.lockCursor = false;
		string score = PlayerPrefs.GetString("lastScore");
		result.text = "You managed to survive " + score +" Better luck next time!";

	}
}
