using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

	private int currentHealth = 50;
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log("enemy health: " + currentHealth);
		if(currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void Damage(int damage)
	{
		currentHealth -= damage;
	}
}
