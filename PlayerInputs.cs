using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInputs : MonoBehaviour
{
	public GameObject inventory;
	public FirstPersonController fpc;

	public bool inventoryActive = false;

	private void Awake()
	{
		fpc = GetComponent<FirstPersonController>();
	}

	// Use this for initialization
	void Start ()
	{
		inventory = GameObject.FindGameObjectWithTag("inventoryScreen");
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		inventory.SetActive(inventoryActive);
		if (Input.GetKeyDown(KeyCode.I))
		{ 
			inventoryActive = !inventoryActive;
			//Screen.lockCursor = !inventoryActive;
			fpc.Changemode = !inventoryActive;
		}

		if (inventoryActive)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = inventoryActive;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		
	}
}
