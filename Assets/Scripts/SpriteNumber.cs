using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteNumber : MonoBehaviour {


	
	public Sprite[] numbers;
	/*
	[UnityEngine.HideInInspector]
	public SpriteRenderer render;
	*/

	// Use this for initialization
	void Awake ()
	{
		//used so that we can use the Bounds function
		this.gameObject.GetComponent<Image> ().sprite = numbers[0];
	}


	public void SetNumber(int number)
	{
		this.gameObject.GetComponent<Image>().sprite = numbers [number];
	}
}
