using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour 
{

	private Player_Movement player;

	public int currentHealth;
	private int maxHealth = 100;

	

	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
		currentHealth = maxHealth;
	}
	
	
	void Update () 
	{
		Debug.Log("player health: " + currentHealth);
		if(currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
		if(currentHealth <= 0)
		{
			Die();
		}
		if (gameObject.transform.position.y < -7)
		{
			Die();
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
 		if(collider.gameObject.tag == "Enemy")
 		{
 			currentHealth -= 10;

 			StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
 		}  
 	}

	public void Damage (int damage)
	{
		currentHealth -= damage;
	}

	void Die ()
	{	
		SceneManager.LoadScene ("Prototype_1");
	}
}
