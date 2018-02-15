using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

// Keyboard Inputs
// What's happenning to the player's RB
// Transform modifications

	private Rigidbody2D rb2d;

	private Ray2D touchingGroundRay;
	private RaycastHit2D myRCH;
	//private Ray2D attackRay;
	//private RaycastHit2D attackHit;

	public bool facingRight = true;
	private float moveX;



	// Use this for initialization
	private void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
		{
			rb2d.AddForce(Vector3.right * -50);
		}
		if(Input.GetKey(KeyCode.D))
		{
			rb2d.AddForce(Vector3.right * 50);
		}

		touchingGroundRay = new Ray2D(transform.position - Vector3.up * .35f, Vector3.up * -.1f);

		//Debug.DrawRay(touchingGroundRay.origin, touchingGroundRay.direction * .1f);

		myRCH = Physics2D.Raycast (touchingGroundRay.origin, touchingGroundRay.direction, .1f);

		//Debug.Log (myRCH.collider.gameObject.name);

		if(Input.GetKeyDown(KeyCode.W))
		{
			if (myRCH.collider.tag == "Ground" || myRCH.collider.tag == "Enemy")
			{
				//Debug.Log ("this works");
				rb2d.AddForce(Vector3.up *20, ForceMode2D.Impulse);
			}
		}
		
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

	public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection)
	{
		float timer = 0;
		while (knockDuration > timer)
		{
			timer += Time.deltaTime;
			rb2d.AddForce(new Vector3(knockDirection.x * -100, knockDirection.y * knockPower, transform.position.z));
		}

		yield return 0;
	}


}












