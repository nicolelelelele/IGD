using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour 
{
	public Rigidbody2D rb2d;
	public GameObject patrolPath;
	private float speed = 0.05f;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		transform.position += Vector3.right * speed;
	}

	void OnTriggerEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Stoppers")
		{
			speed = speed * -1;
		}
	}
}
