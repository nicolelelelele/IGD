using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour 
{
	private bool attacking;
	private float attackTimer = 0f;
	private float attackCoolDown = 0.3f;

	public Collider2D attackTrigger;
	
	void Awake()
	{
		attackTrigger.enabled = false;
	}
	
	
	void Update () 
	{
		
		if (Input.GetKeyDown(KeyCode.Space) && !attacking)
		{
			attacking = true;
			attackTimer = attackCoolDown;

			attackTrigger.enabled = true;
		}

		if (attacking)
		{
			if (attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			}
			else
			{
				attacking = false;
				attackTrigger.enabled = false;
			}
		}

	}
}