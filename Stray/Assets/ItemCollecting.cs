using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecting : MonoBehaviour 
{

	private SpriteRenderer item;
	public GameObject text;
	public GameObject itemButton;
	public GameObject notif;

	private bool startTimer = false;
	private bool timesUp = false;

	private float timer;
	public float notifDuration;
	
	void Start () 
	{
		item = gameObject.GetComponent<SpriteRenderer>();
		itemButton.GetComponent<Button>().interactable = false;
	}

	void Update()
	{
		if(startTimer)
		{
			if(notifDuration > timer)
			{
				timer += Time.deltaTime;
				timesUp = false;
			}
			else
			{
				notif.SetActive(false);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			text.SetActive(true);
			itemButton.GetComponent<Button>().interactable = true;
			//gameObject.SetActive(false);
			item.enabled = false;

			NewItemNotif();
			//transform.position = new Vector2 (200,200);
			//notes = notes + 1;
		}
	}

	void NewItemNotif()
	{
		//Debug.Log("new item!");
		notif.SetActive(true);
		startTimer = true;		
	}
}
