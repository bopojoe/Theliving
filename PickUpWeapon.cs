using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour {
	
	public Image gunImage;
	public Text ammoNum;
	public Image ammoPic;
	private float objTimer;
	
	
	
	private void Awake()
	{
		gunImage.enabled = false;
		ammoNum.enabled = false;
		ammoPic.enabled = false;

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<BoxCollider>().enabled == false)
		{
			
			objTimer += Time.deltaTime % 60;
			if(objTimer < 300f){
				//print(objTimer);
			}else{
				this.gameObject.GetComponent<MeshRenderer>().enabled = true;
				this.gameObject.GetComponent<BoxCollider>().enabled = true;
			}
		}
		
	}
	
	private void OnTriggerEnter(Collider other)
	{
		print(this.gameObject.tag);
		
		if (other.tag == "Player" && this.gameObject.tag == "shotgun")
		{
			if (!gunImage.IsActive())
			{
				gunImage.enabled = true;
				ammoNum.enabled = true;
				ammoPic.enabled = true;
				other.GetComponent<PlayerInputs>().hasShotgun = true;
				Destroy(this.gameObject);
				
			}
		}

		if (other.tag == "Player" && this.gameObject.tag == "ammo")
		{
			other.GetComponent<InventoryLists>().addAmmo(8);
			objTimer = 0;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
