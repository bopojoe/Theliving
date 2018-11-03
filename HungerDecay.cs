using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerDecay : MonoBehaviour {
	
	public UnityEngine.UI.Image hud;
	private float hunger = 150f;
	private float timer;
	private Health health;
	
	public List<Sprite> imageList = new List<Sprite>();
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;
	public Sprite sprite6;
	public Sprite sprite7;
	public Sprite sprite8;
	public Sprite sprite9;
	public Sprite sprite10;
	public Sprite sprite11;
	public Sprite sprite12;
	public Sprite sprite13;
	public Sprite sprite14;
	public Sprite sprite15;
	public Sprite sprite16;

	private void Awake()
	{
		health = GetComponent<Health>();
		imageList.Add(sprite1);
		imageList.Add(sprite2);
		imageList.Add(sprite3);
		imageList.Add(sprite4);
		imageList.Add(sprite5);
		imageList.Add(sprite6);
		imageList.Add(sprite7);
		imageList.Add(sprite8);
		imageList.Add(sprite9);
		imageList.Add(sprite10);
		imageList.Add(sprite11);
		imageList.Add(sprite12);
		imageList.Add(sprite13);
		imageList.Add(sprite14);
		imageList.Add(sprite15);
		imageList.Add(sprite16);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime % 60;
		decay();
		setPlayerHud(hunger);
	}


	void decay()
	{
		if (timer >= 9.9)
		{
			timer = 0;
			if (hunger > 0)
			{
				hunger -= 10;
			}
			else
			{
				health.HealthPoints -= 5;
			}
		}
	}
	
	void setPlayerHud(float hunger)
	{
		if (hunger >= 141)
		{
			hud.sprite = imageList[15] ;
		}
		else if(hunger>=131)
		{
			hud.sprite = imageList[14] ;
		}else if(hunger>=121)
		{
			hud.sprite = imageList[13] ;
		}else if(hunger>=111)
		{
			hud.sprite = imageList[12] ;
		}else if(hunger>=101)
		{
			hud.sprite = imageList[11] ;
		}else if(hunger>=91)
		{
			hud.sprite = imageList[10] ;
		}else if(hunger>=81)
		{
			hud.sprite = imageList[9] ;
		}else if(hunger>=71)
		{
			hud.sprite = imageList[8] ;
		}else if(hunger>=61)
		{
			hud.sprite = imageList[7] ;
		}else if(hunger>=51)
		{
			hud.sprite = imageList[6] ;
		}else if(hunger>=41)
		{
			hud.sprite = imageList[5] ;
		}else if(hunger>=31)
		{
			hud.sprite = imageList[4] ;
		}else if(hunger>=21)
		{
			hud.sprite = imageList[3] ;
		}else if(hunger>=11)
		{
			hud.sprite = imageList[2] ;
		}else if(hunger>=1)
		{
			hud.sprite = imageList[1] ;
		}else if(hunger>=0)
		{
			hud.sprite = imageList[0] ;
		}
	}

	public void addHunger(float value)
	{
		hunger += value;
	}
}
