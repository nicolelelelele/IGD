using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

// Keyboard Inputs
// What's happenning to the player's RB
// Transform modifications

	private Rigidbody2D _myRB2D;

	private Ray2D _touchingGroundRay;
	private RaycastHit2D _myRCH;
	private Ray2D attackRay;
	private RaycastHit2D attackHit;

	public bool facingRight = true;
	public float moveX;



	// Use this for initialization
	private void Start () 
	{
		_myRB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
		{
			_myRB2D.AddForce(Vector3.right * -50);
		}
		if(Input.GetKey(KeyCode.D))
		{
			_myRB2D.AddForce(Vector3.right * 50);
		}

		_touchingGroundRay = new Ray2D(transform.position - Vector3.up * .35f, Vector3.up * -.1f);

		//Debug.DrawRay(_touchingGroundRay.origin, _touchingGroundRay.direction * .1f);

		_myRCH = Physics2D.Raycast (_touchingGroundRay.origin, _touchingGroundRay.direction, .1f);

		//Debug.Log (_myRCH.collider.gameObject.name);

		if(Input.GetKeyDown(KeyCode.W))
		{
			if (_myRCH.collider.tag == "Ground" || _myRCH.collider.tag == "Enemy")
			{
				//Debug.Log ("this works");
				_myRB2D.AddForce(Vector3.up *20, ForceMode2D.Impulse);
			}
		}

		/*attackRay = new Ray2D(transform.position + Vector3.right * .5f, Vector3.right);
		
		attackHit = Physics2D.Raycast(attackRay.origin, attackRay.direction, .1f);
		//Debug.Log(attackHit.collider.gameObject.name);
		if(Input.GetKeyDown(KeyCode.Return))
		{
			if (attackHit.collider.tag == "Enemy")
			{
				Destroy(attackHit.collider.gameObject);
			}
		}*/
		
		moveX = Input.GetAxis("Horizontal");

		if(moveX > 0.0f && facingRight == false)
		{
			//Debug.Log(facingRight);
			FlipPlayer();
		}
		else if(moveX < 0.0f && facingRight == true)
		{
			//Debug.Log(facingRight);
			FlipPlayer();
		}


	}

	void FlipPlayer()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}




}










// F/I -> RB



