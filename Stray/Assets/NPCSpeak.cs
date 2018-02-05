using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpeak : MonoBehaviour 
{
	public GameObject speechBubble;
	private Vector2 npcPosition;
	private float npcX;
	private float npcY;

	// Use this for initialization
	void Start () 
	{
		npcPosition = gameObject.transform.position;
		npcX = npcPosition.x;
		npcY = npcPosition.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void OnTriggerStay2D()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			Instantiate(speechBubble, new Vector2(npcX + 2, npcY + 1), Quaternion.identity);
		}
	}
}
