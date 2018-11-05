using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

	public GameObject audioSource;
	
	public AudioClip songOne;
	public AudioClip songTwo;
	public AudioClip songThree;
	public AudioClip songFour;
	private AudioSource source;

	// Use this for initialization
	void Start ()
	{
		source = audioSource.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "mZone1")
		{
			source.enabled = false;
			source.clip = songOne;
			source.enabled = true;
		}
		if (other.tag == "mZone2")
		{
			source.enabled = false;
			source.clip = songTwo;
			source.enabled = true;
		}
		if (other.tag == "mZone3")
		{
			source.enabled = false;
			source.clip = songThree;
			source.enabled = true;
		}
		if (other.tag == "mZone4")
		{
			source.enabled = false;
			source.clip = songFour;
			source.enabled = true;
		}
	}
	

	

	
}
