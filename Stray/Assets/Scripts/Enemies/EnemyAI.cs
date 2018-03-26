using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour 
{

	public int enemySpeed;
	public int xMoveDirection;

	void Start()
	{

	}

	void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (xMoveDirection, 0) * enemySpeed; 
		if (hit.distance < 0.3f)
		{
			Flip();	

		}
	}

	/*void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "EnemyBump")
		{
			Debug.Log("bumped");
			Flip();
		}
	}*/

	void Flip()
	{
		if (xMoveDirection > 0)
		{
			xMoveDirection = -1; 
		}
		else
		{
			xMoveDirection = 1; 	
		}
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	
}
