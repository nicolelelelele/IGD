using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Collecting : MonoBehaviour 
{

	private int notes;
	public Text collectiblesCounter;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log("notes: " + notes);
		collectiblesCounter.text = "Collectibles: " + notes + "/10";
	}

	void OnTriggerStay2D ()
	{
		//Debug.Log("collected");
		transform.position = new Vector2 (200,200);
		notes = notes + 1;
	}
}
