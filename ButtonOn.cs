using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject obj;
	public void ButtonTextChange()
	{
		obj.gameObject.GetComponent<Text>().text = "hello";
	}
}
