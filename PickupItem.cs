using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{

	public GameObject food;
	public GameObject shotgun;
	public GameObject ammo;
	public GameObject axe;
	
	
	
	GameObject obj;

	private float objTimer;

	private float time;
	private int collected;
	private bool dayTimerBool;

	private float day = 0;
	private float cooldownTimer = 0;
	private float oneDay = 1800;

	private bool cooldown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dayTimerBool)
		{
			day += Time.deltaTime % 60;		
		}
		if (collected==3&& day<oneDay) //oneday
		{
			cooldown = true;
			print("cooldowned");
			collected = 0;
			day = 0;
		}
		if (cooldown)
		{
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			cooldownTimer += Time.deltaTime % 60;
		}
		
		
		if (this.gameObject.GetComponent<BoxCollider>().enabled == false&&!cooldown)
		{
			
			objTimer += Time.deltaTime % 60;
			if(objTimer < time){
				//wait
				//print(objTimer);
			}else{
				this.gameObject.GetComponent<MeshRenderer>().enabled = true;
				this.gameObject.GetComponent<BoxCollider>().enabled = true;
			}
		}
//oneday
		if (cooldownTimer>oneDay)
		{
			cooldown = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = true;
			this.gameObject.GetComponent<BoxCollider>().enabled = true;
			time = 0;

		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
		{
			
			if (this.gameObject.tag == "food")
			{
				obj = food;
			}
			


			other.GetComponent<InventoryLists>().addToList(obj);
			objTimer = 0;
			time = time+time+60; //60
			print(time);
			collected++;
			dayTimerBool = true;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			print(this.gameObject.tag+" object added to list");
		}
	}

	
}
