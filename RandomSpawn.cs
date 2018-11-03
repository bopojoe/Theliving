using System.Collections;
using System.Collections.Generic;
using Gaia;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class RandomSpawn : MonoBehaviour
{
	public GameObject player;
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;
	public GameObject spawn4;
	public GameObject spawn5;
	public GameObject spawn6;
	
	List<GameObject> list = new List<GameObject>();
	

	private void Awake()
	{
		
		list.Add(spawn1);
		list.Add(spawn2);
		list.Add(spawn3);
		list.Add(spawn4);
		list.Add(spawn5);
		list.Add(spawn6);
		//int num = Random.Range(0, 5);
		int num =5;
		GameObject setSpawn = list[num];
		player.transform.position = setSpawn.transform.position;
		player.SetActive(true);
		//print("Spawn position "+num+" selected");

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
