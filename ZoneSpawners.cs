using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class ZoneSpawners : MonoBehaviour {
	//array of zone triggers
	GameObject[] heatZones1;
	GameObject[] heatZones2;
	GameObject[] heatZones3;
	GameObject[] heatZones4;
	
	// heat total for each quadrant
	public int zone1Total = 0;
	public int zone2Total = 0;
	public int zone3Total = 0;
	public int zone4Total = 0;
	
	//spawn rate per Quadrant
	public int spawnRate1 = 0;
	public int spawnRate2 = 0;
	public int spawnRate3 = 0;
	public int spawnRate4 = 0;
	
	//array zombies in each zone
	GameObject[] zombieTotal1;
	GameObject[] zombieTotal2 ;
	GameObject[] zombieTotal3 ;
	GameObject[] zombieTotal4 ;
	
	//total zombies in each zone
	public int z1 = 0;
	public int z2 = 0;
	public int z3 = 0;
	public int z4 = 0;
		
	
	//max zombies for each zone
	public int maxZombieForZone1 = 0;
	public int maxZombieForZone2 = 0;
	public int maxZombieForZone3 = 0;
	public int maxZombieForZone4 = 0;
	
	
	//zombie prefabs
	public GameObject Zombie1;
	public GameObject Zombie2;
	public GameObject Zombie3;
	public GameObject Zombie4;

	
	// Use this for initialization
	void Start () {
		heatZones1 = GameObject.FindGameObjectsWithTag("zone1");
		heatZones2 = GameObject.FindGameObjectsWithTag("zone2");
		heatZones3 = GameObject.FindGameObjectsWithTag("zone3");
		heatZones4 = GameObject.FindGameObjectsWithTag("zone4");
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		zombieTotal1 = GameObject.FindGameObjectsWithTag("z1");
		zombieTotal2 = GameObject.FindGameObjectsWithTag("z2");
		zombieTotal3 = GameObject.FindGameObjectsWithTag("z3");
		zombieTotal4 = GameObject.FindGameObjectsWithTag("z4");
		
		z1 = totalZombieCalculator(zombieTotal1);
		z2 = totalZombieCalculator(zombieTotal2);
		z3 = totalZombieCalculator(zombieTotal3);
		z4 = totalZombieCalculator(zombieTotal4);

		zone1Total = totalCalculator(heatZones1);
		zone2Total = totalCalculator(heatZones2);
		zone3Total = totalCalculator(heatZones3);
		zone4Total = totalCalculator(heatZones4);
		
		spawnRate1 = spawnRate(zone1Total);
		spawnRate2 = spawnRate(zone2Total);
		spawnRate3 = spawnRate(zone3Total);
		spawnRate4 = spawnRate(zone4Total);
		
		maxZombieForZone1 = maxZombie(spawnRate1);
		maxZombieForZone2 = maxZombie(spawnRate2);
		maxZombieForZone3 = maxZombie(spawnRate3);
		maxZombieForZone4 = maxZombie(spawnRate4);

		spawnZombies(maxZombieForZone1, "Zspawn1", z1);
		spawnZombies(maxZombieForZone2, "Zspawn2", z2);
		spawnZombies(maxZombieForZone3, "Zspawn3", z3);
		spawnZombies(maxZombieForZone4, "Zspawn4", z4);
		
	}

	int totalCalculator(GameObject[] zone)
	{
		int total = 0;
		foreach (GameObject heatzone in zone)
		{
			int value = heatzone.GetComponent<HeatMap>().heat;
			total += value;
			
		}

		return total;
	}
	
	int totalZombieCalculator(GameObject[] zombies)
	{
		int total = 0;
		foreach (GameObject zombie in zombies)
		{
			
			total ++;
			
		}

		return total;
	}


	int spawnRate(int zonetotal)
	{
		int rate;
		if (zonetotal > 200)
		{
			rate = 4;
		
		}else if (zonetotal > 100)
		{
			rate = 3;
			
		}else if (zonetotal > 50)
		{
			rate = 2;
		}
		else
		{
			rate = 1;
		
		}

		return rate;
	}
	
	int maxZombie(int rate)
	{
		switch (rate)
		{
			case 4:
				return 40;
			case 3:
				return 30;
			case 2:
				return 20;
			case 1:
				return 10;
			default:
				return 10;
			
		}
	}

/**
 * NEEDS EDITING CRASHING UNITY
 * NEED TO MAKE USE GPU
 */
	void spawnZombies(int zonemax, string tagName, int zombies)
	{
		//string tagName = gameObject.tag;
		GameObject zombie = Zombie1;

		if (tagName == gameObject.tag && zombies<zonemax)
		{
			if (tagName == "Zspawn4")
			{
				zombie = Zombie4;
			}else if (tagName == "Zspawn3")
			{
				zombie = Zombie3;
			}else if (tagName == "Zspawn2")
			{
				zombie = Zombie2;
			}else if (tagName == "Zspawn1")
			{
				zombie = Zombie1;
			}
			
           
            	Vector3 pos = gameObject.GetComponent<Transform>().position; 
            	Instantiate(zombie, new Vector3(pos.x,pos.y,pos.z), transform.rotation);
			print("zomble spawned");
		}
		
	}
	
	
	
	
	
	
	
}
