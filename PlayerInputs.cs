using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInputs : MonoBehaviour
{
	public GameObject inventory;
	public GameObject mapCam;
	public FirstPersonController fpc;

	public bool inventoryActive = false;
	public bool mapActive = false;
	public bool hasShotgun = false;
	//weapons
	public bool shotgunOn = false;
	private bool axeOn = false;
	private bool handsOn = true;
	private bool timeout;
	public GameObject shotgunObj;
	public GameObject crosshair;
	public GameObject mussel1;
	public GameObject mussel2;
	public GameObject mussel3;
	public GameObject bullet;
	public GameObject gunSound;
	private float timer = 2f;

	private void Awake()
	{
		fpc = GetComponent<FirstPersonController>();
		gunSound.SetActive(false);
	}

	// Use this for initialization
	void Start ()
	{
		inventory = GameObject.FindGameObjectWithTag("inventoryScreen");
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (timeout)
		{
			timer -= Time.deltaTime;
		}

		if (timer<=0)
		{
			timeout = false;
			timer = 2;
			gunSound.SetActive(false);
		}

		inventory.SetActive(inventoryActive);
		mapCam.SetActive(mapActive);
		
		if (Input.GetKeyDown(KeyCode.M))
		{
			mapActive = !mapActive;
		}

		if (mapActive)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
		
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
				axeOn = false;
				shotgunOn = true;
				handsOn = false;
				
			}
			
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
				shotgunOn = false;
				axeOn = true;
				handsOn = false;
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			shotgunOn = false;
			axeOn = false;
			handsOn = false;
			
			
			
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
		

		if (Input.GetMouseButtonDown(0) && shotgunObj.active&&!timeout)
		{
			int ammo = GetComponent<InventoryLists>().ammoCount;
			print(ammo+" ammo left");
			if (ammo > 0)
			{
			
				GameObject p1 = (GameObject) Instantiate(bullet, mussel1.transform.position, Quaternion.identity);
				p1.transform.rotation = mussel1.transform.rotation;
				GameObject p2 = (GameObject) Instantiate(bullet, mussel2.transform.position, Quaternion.identity);
				p2.transform.rotation = mussel2.transform.rotation;
				GameObject p3 = (GameObject) Instantiate(bullet, mussel3.transform.position, Quaternion.identity);
				p3.transform.rotation = mussel3.transform.rotation;
				
				gunSound.SetActive(true);

				
				GetComponent<InventoryLists>().ammoCount -= 1;
				timeout = true;
				

			}
		}

	}
}
