using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Ai_Zombie_simple : MonoBehaviour {
	
	SphereCollider ThisCollider = null;
	
	private LineSight lineSight = null;
	private AICharacterControl aiControl = null;
	private float timer = 0;
	
	

	private void Awake()
	{
		ThisCollider = GetComponent<SphereCollider>();
		lineSight = GetComponent<LineSight>();
		aiControl = GetComponent<AICharacterControl>();
		

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//chase();
	}

	void chase()
	{
		if (lineSight.CanSeeTarget)
		{
			timer = 10;
			//aiControl.agent.SetDestination(lineSight.LastKnowSighting);

		}
		else if(timer>0)
		{
			timer -= Time.deltaTime;
			
		}

		while (timer>0)
		{
		//	aiControl.agent.SetDestination(lineSight.LastKnowSighting);
		}

		/*if (aiControl.target == null)
		{
			GameObject[] Destinations = GameObject.FindGameObjectsWithTag("Dest");
			aiControl.target = Destinations[Random.Range(0, Destinations.Length)].GetComponent<Transform>();
		}*/
		
	}

	
}
