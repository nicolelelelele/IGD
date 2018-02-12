using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpeak : MonoBehaviour 
{
	public GameObject collectible;
	private Vector2 npcPosition;
	private float npcX;
	private float npcY;
	private bool noteGiven;

	// Use this for initialization
	void Start () 
	{
		npcPosition = gameObject.transform.position;
		npcX = npcPosition.x;
		npcY = npcPosition.y;
		noteGiven = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnTriggerStay2D()
	{
		if(Input.GetKeyDown(KeyCode.S) && noteGiven == false)
		{
			Instantiate(collectible, new Vector2(npcX + 1, npcY + .5f), Quaternion.identity);
			noteGiven = true;
		}
	}
}
