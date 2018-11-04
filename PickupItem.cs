using System.Collections;
using System.Collections.Generic;
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

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<BoxCollider>().enabled == false)
		{
			
			objTimer += Time.deltaTime % 60;
			if(objTimer < 10f){
				//print(objTimer);
			}else{
				this.gameObject.GetComponent<MeshRenderer>().enabled = true;
				this.gameObject.GetComponent<BoxCollider>().enabled = true;
			}
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
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			print(this.gameObject.tag+" object added to list");
		}
	}

	
}
