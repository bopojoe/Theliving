using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 35);
		Destroy(gameObject,3);
	}

/*	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="enemy")
		{
			Destroy(gameObject);
			other.GetComponent<ZombieHealth>().healthPoints -= 50;
		}
	}*/
}
