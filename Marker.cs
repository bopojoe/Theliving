using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
	public GameObject easy;
	public GameObject medium;
	public GameObject death;
	public GameObject easyButton;
	public GameObject mediumButton;
	public GameObject deathButton;
	

// Use this for initialization
	void Start ()
	{
		activateEasy();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activateEasy()
	{
		changeInteract();
		medium.SetActive(false);
		death.SetActive(false);
		easy.SetActive(true);
		easyButton.GetComponent<Button>().interactable = false;
		
	}
	
	public void activateMedium()
	{
		changeInteract();
		easy.SetActive(false);
		death.SetActive(false);
		medium.SetActive(true);
		mediumButton.GetComponent<Button>().interactable = false;
		
		
	}
	
	public void activateDeath()
	{
		changeInteract();
		medium.SetActive(false);
		easy.SetActive(false);
		death.SetActive(true);
		deathButton.GetComponent<Button>().interactable = false;
	}

	void changeInteract()
	{
		easyButton.GetComponent<Button>().interactable = true;
		mediumButton.GetComponent<Button>().interactable = true;
		deathButton.GetComponent<Button>().interactable = true;
	}
	
}
