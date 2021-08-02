using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSet : MonoBehaviour
{
 	public NumberRenderer theScore;

	public int score;

	// Use this for initialization
	void Start () 
	{
		//This is the main render function. Give this fuction the number you want to render.
		theScore.RenderNumber (0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		theScore.RenderNumber (score); //Render the score
	}

}
