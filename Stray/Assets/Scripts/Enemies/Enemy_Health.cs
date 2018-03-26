using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour {

	public int currentHealth;
	public GameObject item;
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log("enemy health: " + currentHealth);
		if(currentHealth <= 0)
		{
			Destroy(gameObject);
			item.SetActive(true);
		}
	}

	public void Damage(int damage)
	{
		currentHealth -= damage;
	}
}
