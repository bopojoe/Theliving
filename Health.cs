using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.Experimental.UIElements.Image;

public class Health : MonoBehaviour
{
	public UnityEngine.UI.Image hud;
	public UnityEngine.UI.Text time;
	public UnityEngine.UI.Text newText;
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
	
	public int damage = 75;
	//test to see whats happening
	public GameObject obj;

	private void Awake()
	{
		obj = this.gameObject;
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

	private void Update()
	{
		if(this.gameObject.tag=="Player")
		setPlayerHud(healthPoints);
		
	}

	public float HealthPoints
	{
		get{return healthPoints;}
		set
		{
			healthPoints = value;

			//If health is < 0 then die
			if (healthPoints <= 0&&this.gameObject.tag=="Player")
			{
				dead();
			}
		else if(healthPoints <= 0 && gameObject.tag=="enemy")
			{
				zombieDead();
			}
		}
		
	}

	[SerializeField]
	private float healthPoints = 150f;

	void setPlayerHud(float healthPoints)
	{
		if (healthPoints >= 141)
		{
			hud.sprite = imageList[15] ;
		}
		else if(healthPoints>=131)
		{
			hud.sprite = imageList[14] ;
		}else if(healthPoints>=121)
		{
			hud.sprite = imageList[13] ;
		}else if(healthPoints>=111)
		{
			hud.sprite = imageList[12] ;
		}else if(healthPoints>=101)
		{
			hud.sprite = imageList[11] ;
		}else if(healthPoints>=91)
		{
			hud.sprite = imageList[10] ;
		}else if(healthPoints>=81)
		{
			hud.sprite = imageList[9] ;
		}else if(healthPoints>=71)
		{
			hud.sprite = imageList[8] ;
		}else if(healthPoints>=61)
		{
			hud.sprite = imageList[7] ;
		}else if(healthPoints>=51)
		{
			hud.sprite = imageList[6] ;
		}else if(healthPoints>=41)
		{
			hud.sprite = imageList[5] ;
		}else if(healthPoints>=31)
		{
			hud.sprite = imageList[4] ;
		}else if(healthPoints>=21)
		{
			hud.sprite = imageList[3] ;
		}else if(healthPoints>=11)
		{
			hud.sprite = imageList[2] ;
		}else if(healthPoints>=1)
		{
			hud.sprite = imageList[1] ;
		}else if(healthPoints>=0)
		{
			hud.sprite = imageList[0] ;
		}
	}



	void dead()
	{
	
		PlayerPrefs.SetString("lastScore", time.text);
	
		Destroy(gameObject);
		SceneManager.LoadScene(4);
	
		//newText.text = "You managed to stay alive for "+time.text+" /n better luck next time";
	}

	void zombieDead()
	{
		Destroy(obj);
		print("zombie dead");
		//instanciate food
	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="bullet")
		{
			Destroy(other.gameObject);
			healthPoints -= damage;
		}
	}

/*	private void OnCollisionStay(Collision other)
	{
		while(other.gameObject.tag=="enemy")
		{
			healthPoints -= 10;
		}
	}*/
}
