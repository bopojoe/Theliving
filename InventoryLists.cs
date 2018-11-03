using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryLists : MonoBehaviour
{
	private string name;
	public Text slot1;
	public Text slot2;
	public Text slot3;
	public Image image1;
	public Image image2;
	public Image image3;
	public Text value1;
	public Text value2;
	public Text value3;
	public Sprite food;
	private bool invOn = false;
	
	
	public List<GameObject> inventory = new List<GameObject>();

	

	private void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown(KeyCode.I))
		{
			invOn = true;
		}
		if (invOn)
		{
			value1.text = ""+listItems();
			slot1.text = name;
			if (name == "food")
			{
				image1.sprite = food;
			}
			
		}

		name = "";

	}

	public void addToList(GameObject obj)
	{
		inventory.Add(obj);
	}


	   void printList()
	{
		if (Input.GetKeyDown(KeyCode.V))
		{
			
			foreach(GameObject item in inventory)
			{
				print (item);
			}
		}
	}

	int listItems()
	{
		int count = 0;
		
		foreach(GameObject item in inventory)
		{
			count++;
			name = item.tag;
		}

		return count;
	}
	
	
	
}
