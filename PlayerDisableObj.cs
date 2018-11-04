using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerDisableObj : MonoBehaviour
{


	public Image gunImage;
	public Text ammoNum;
	public Image ammoPic;
	



	private void Awake()
	{
		gunImage.enabled = false;
		ammoNum.enabled = false;
		ammoPic.enabled = false;

	}
}
