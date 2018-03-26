using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour 
{
	private Rigidbody2D rb2d;
	private Player_Movement player;

	public int currentHealth;
	private int maxHealth = 200;
	public Text healthCounter;

//	private Vector2 playerPosition;
//	private float playerX;
//	private float playerY;

	//public Collider2D enemyBump;
	//private bool bumping;
	//private float timer = .2f;

	void Awake()
	{
		//enemyBump.enabled = false;
	}
	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
		currentHealth = maxHealth;
		rb2d = GetComponent<Rigidbody2D>();
		//playerPosition = gameObject.transform.position;
		//playerX = playerPosition.x;
		//playerY = playerPosition.y;
	}
	
	
	void Update () 
	{
		//Debug.Log("player health: " + currentHealth);
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
		healthCounter.text = "Health: " + currentHealth;
	}

	void OnTriggerStay2D(Collider2D collider)
	{
 		if(collider.gameObject.tag == "Enemy")
 		{
 			currentHealth -= 1;
 			//enemyBump.enabled = false;
 			//StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
 		}  
 		/*if(collider.gameObject.tag == "EnemyBack")
 		{
 			enemyBump.enabled = true;
 		}
 			//enemyBump.enabled = false; */
 		
 		if(collider.gameObject.tag == "Health")
 		{
 			currentHealth += 25;
 			Destroy(collider.gameObject);
 		}
 	}

	public void Damage (int damage)
	{
		currentHealth -= damage;
	}

	void Die ()
	{	
		SceneManager.LoadScene ("Visuals");
	}
}
