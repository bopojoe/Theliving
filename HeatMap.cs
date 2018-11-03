using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using TMPro;
using UnityEngine;

public class HeatMap : MonoBehaviour
{
	public bool zoneInactive;
	public int heat;
	private float timer;
	public float timeGone;
	private int timer2;
	public int timer3;
	private string tagName;
	

	// Use this for initialization
	void Start () {
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		if(zoneInactive&&heat>0)
		{
			
			timeGone += Time.deltaTime;
			timer3 = (int)timeGone % 60;
			if (timer3 > 29)
			{
				heat--;
				timeGone = 0;
				print(heat);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			zoneInactive = false;
			tagName = GetComponent<Collider>().tag;
			
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			timer += Time.deltaTime;
			timer2 = (int) timer % 60;
			//print("seconds: "+ timer2+", "+"timer: "+timer);
			if (timer2 > 3)
			{
				
				timer = 0;
				heat++;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		timeGone = 0;
		zoneInactive = true;
	}



}
