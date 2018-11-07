using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {

	[SerializeField]
	private float healthPoints = 150f;
	
	public int damage = 75;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (healthPoints <= 0)
		{
			Destroy(gameObject);
		}
	}

	public float HealthPoints
	{
		get{return healthPoints;}
		set
		{
			healthPoints = value;
			
		
		}
		
	}
	
	
	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="bullet")
		{
			Destroy(other.gameObject);
			healthPoints -= damage;
		}
	}
	
}
