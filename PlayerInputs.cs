﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInputs : MonoBehaviour
{
	public GameObject inventory;
	public FirstPersonController fpc;

	public bool inventoryActive = false;
	public bool hasShotgun = false;
	public bool shotgunOn = false;

	public GameObject shotgunObj;
	public GameObject crosshair;
	public GameObject mussel;
	public GameObject bullet;

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

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (hasShotgun)
			{
				shotgunOn = !shotgunOn;
			}
			
		}
		
		if (shotgunOn)
		{
			shotgunObj.SetActive(true);
			crosshair.SetActive(true);
		}
		else
		{
			shotgunObj.SetActive(false);
			crosshair.SetActive(false);
		}
		//gun only accurate while walking

		if (Input.GetMouseButtonDown(1) && shotgunObj.active)
		{
			int ammo = GetComponent<InventoryLists>().ammoCount;
			print(ammo+" ammo left");
			if (ammo > 0)
			{
				//Quaternion rotation = Quaternion.LookRotation(mussel.transform.position, mussel.transform.position);
				GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
				GameObject p = (GameObject) Instantiate(bullet, mussel.transform.position, camera.transform.rotation);
				//p.GetComponent<Transform>().rotation = camera.GetComponent<Transform>().rotation;

				p.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
				GetComponent<InventoryLists>().ammoCount -= 1;
				Destroy(p, 3);
				
			}
		}

	}
}
