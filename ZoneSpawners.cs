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
	
	//total zombies in each zone
	public int zombieTotal1 = 0;
	public int zombieTotal2 = 0;
	public int zombieTotal3 = 0;
	public int zombieTotal4 = 0;
	
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


	int spawnRate(int zonetotal)
	{
		int rate;
		if (zonetotal > 40)
		{
			rate = 4;
		
		}else if (zonetotal > 30)
		{
			rate = 3;
			
		}else if (zonetotal > 20)
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


	void checkTag()
	{
		if (gameObject.tag == "Zspawn1" )
		{
			
		}
	}
	
	
	
	
	
	
	
}
