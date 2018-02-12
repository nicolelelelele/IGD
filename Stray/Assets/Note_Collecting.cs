using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Collecting : MonoBehaviour 
{

	private int notes;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(notes);
	}

	void OnTriggerStay2D ()
	{
		//Debug.Log("collected");
		transform.position = new Vector2 (200,200);
		notes = notes + 1;
	}
}
