﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentPortal : MonoBehaviour 
{
	public GameObject ventBuddy;
	private Vector2 buddyPosition;
	private float buddyPosX;
	private float buddyPosY;
	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		buddyPosition = ventBuddy.transform.position;
		buddyPosX = buddyPosition.x;
		buddyPosY = buddyPosition.y;
		//Debug.Log("x = " + buddyPosX);
		//Debug.Log("y = " + buddyPosY);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnTriggerStay2D (Collider2D col)
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			player.transform.position = new Vector2(buddyPosX, buddyPosY);
			Debug.Log("entered portal");
		}
	}
}