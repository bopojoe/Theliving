using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class GuiButtons : MonoBehaviour
{

	private InventoryLists inventoryLists;
	private HungerDecay hungerDecay;

	private void Awake()
	{
		inventoryLists = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryLists>();
		hungerDecay = GameObject.FindGameObjectWithTag("Player").GetComponent<HungerDecay>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void useOne()
	{
		int x =int.Parse(inventoryLists.value1.text);
		if (x < 1)
		{
			print("no item to use");
		}
		else
		{
			hungerDecay.addHunger(50);
			int count = inventoryLists.inventory.Count;
			inventoryLists.inventory.RemoveAt(count-1);
			
		}
	}
	
	
}
