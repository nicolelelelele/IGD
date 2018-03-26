using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

	// Keyboard Inputs
	// What's happenning to the player's RB
	// Transform modifications

	public GameObject jumpCounter;

//Rigidbody
	private Rigidbody2D rb2d;

//Rays
	private Ray2D groundRay1;
	private Ray2D groundRay2;
	private Ray2D groundRay3;
	private RaycastHit2D myRCH1;
	private RaycastHit2D myRCH2;
	private RaycastHit2D myRCH3;
	private Ray2D wallRay1;
	private Ray2D wallRay2;
	private RaycastHit2D wallHit1;
	private RaycastHit2D wallHit2;
	//private Ray2D attackRay;
	//private RaycastHit2D attackHit;

//Booleans
	public bool grounded;
	public bool facingRight = true;
	public bool wallSliding;
	public bool wallCheck;

//Floats + Ints
	private float moveX;
	private int jumpsMade = 0;
	public int jumpMax;
	public int jumpsLeft;

//Transforms
	public Transform wallCheckpoint;

//Layer Masks
	public LayerMask wallLayerMask;



	
	private void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		jumpsLeft = jumpMax;
	}
	

	void Update () 
	{


//Move Left/Right
		if(Input.GetKey(KeyCode.A))
		{
			rb2d.AddForce(Vector3.right * -50);
		}
		if(Input.GetKey(KeyCode.D))
		{
			rb2d.AddForce(Vector3.right * 50);
		}

//Draw Ground Rays
		groundRay1 = new Ray2D(transform.position - Vector3.up * .35f, Vector3.up * -.1f);
		groundRay2 = new Ray2D(transform.position - (Vector3.up + Vector3.right)* .35f, Vector3.up * -.1f);
		groundRay3 = new Ray2D(transform.position - (Vector3.up + Vector3.left) * .35f, Vector3.up * -.1f);
		Debug.DrawRay(groundRay1.origin, groundRay1.direction * .1f);
		Debug.DrawRay(groundRay2.origin, groundRay2.direction * .1f);
		Debug.DrawRay(groundRay3.origin, groundRay3.direction * .1f);

//Check Ground Hits
		myRCH1 = Physics2D.Raycast (groundRay1.origin, groundRay1.direction, .1f);
		myRCH2 = Physics2D.Raycast (groundRay2.origin, groundRay2.direction, .1f);
		myRCH3 = Physics2D.Raycast (groundRay3.origin, groundRay3.direction, .1f);

		//Debug.Log ("1" + myRCH1.collider.gameObject.tag);
		//Debug.Log ("2" + myRCH2.collider.gameObject.tag);
		//Debug.Log ("3" + myRCH3.collider.gameObject.tag);

//Jump
		/*if(myRCH1.collider.tag.Contains("Gr"))
		{
			Debug.Log("gr works, look: " + myRCH1.collider.tag);
		}*/
		jumpCounter.SendMessageUpwards("Counter", jumpsLeft);

		//if(myRCH1.collider != null && myRCH2.collider != null && myRCH3.collider != null)
		//{

			if (myRCH1.collider.tag.Contains("Ground") || myRCH2.collider.tag.Contains("Ground") || myRCH3.collider.tag.Contains("Ground") || myRCH1.collider.tag.Contains("Enemy") || myRCH2.collider.tag.Contains("Enemy") || myRCH3.collider.tag.Contains("Enemy"))
			{
				grounded = true;
				jumpsLeft = jumpMax;
				jumpsMade = 0;
				if(Input.GetKeyDown(KeyCode.J) && !wallSliding)
				{		
					if (grounded == true)
					{
						rb2d.AddForce(Vector3.up *20, ForceMode2D.Impulse);	
						
					}
				
				}
			}

		//}
		else
		{
			grounded = false;
		}
		/*if (myRCH1.collider == null || myRCH2.collider == null || myRCH3.collider == null)
		{
			grounded = false;
		}*/
		
//Flip Player		
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

//Draw Wall Rays
		if(facingRight)
		{
			wallRay1 = new Ray2D(transform.position + ((Vector3.right * 1.5f) + (Vector3.up * .75f)) * .35f, Vector3.left * -.1f);
			wallRay2 = new Ray2D(transform.position + ((Vector3.right * 1.5f) - (Vector3.up * .75f)) * .35f, Vector3.left * -.1f);
		}
		if(!facingRight)
		{
			wallRay1 = new Ray2D(transform.position + ((Vector3.left * 1.5f) + (Vector3.up * .75f)) * .35f, Vector3.left * -.1f);
			wallRay2 = new Ray2D(transform.position + ((Vector3.left * 1.5f) - (Vector3.up * .75f)) * .35f, Vector3.left * -.1f);
		}
		Debug.DrawRay(wallRay1.origin, wallRay1.direction * .1f);
		Debug.DrawRay(wallRay2.origin, wallRay2.direction * .1f);

//Check Wall Hits
		
		wallHit1 = Physics2D.Raycast (wallRay1.origin, wallRay1.direction, .1f);
		wallHit2 = Physics2D.Raycast (wallRay2.origin, wallRay2.direction, .1f);
		//Debug.Log("wall 1 " + wallHit1.collider.gameObject.tag);
		//Debug.Log("wall 2 " + wallHit2.collider.gameObject.tag);

//WIP
		//Debug.Log("grounded: " + grounded);
		if(wallHit1.collider != null && wallHit2.collider != null)
		{
			if (wallHit1.collider.tag.Contains("Wall") || wallHit2.collider.tag.Contains("Wall"))
			{
				if(!grounded)
				{
					//Debug.Log("we gon wall slide");
					wallSliding = true;
					wallSlide();
				}
			}
		}
		else
		{
			wallSliding = false;
		}

		Debug.Log("jumps left: " + (jumpMax - jumpsMade));

		/*if (!grounded)
		{
			wallCheck = Physics2D.OverlapCircle(wallCheckpoint.position, 0.1f, wallLayerMask);
			//if(facingRight && Input.GetAxis("Horizontal") < 0.1f || !facingRight && Input.GetAxis("Horizontal") < 0.1f)
			//{
				if(wallCheck)
				{
					Debug.Log("we bouta wall slide");
					wallSlide();
				}
			//}
		}
		if(wallCheck == false || grounded)
		{
			wallSliding = false;
		}*/

	}

	void wallSlide()
	{
		if((facingRight && wallSliding && Input.GetKeyDown(KeyCode.D)) || (!facingRight && wallSliding && Input.GetKeyDown(KeyCode.A)))
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x, -0.7f);
		}
		//wallSliding = true;
		//Debug.Log("wall sliding? :" + wallSliding);
		if(Input.GetKeyDown(KeyCode.J) && jumpsMade < jumpMax)
		{
			Debug.Log("we should wall jump now");
			if(facingRight)
			{
				Debug.Log("Wall Jump Right");
				rb2d.AddForce(new Vector2(-800, 1000));
				jumpsMade++;
				jumpsLeft--;
			}
			else
			{
				Debug.Log("Wall Jump Left");
				rb2d.AddForce(new Vector2(800, 1000));
				jumpsMade++;
				jumpsLeft--;
			}
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Enemy")
		{
			if(facingRight)
			{
				rb2d.AddForce(new Vector2(-100, 200));
			}
			else
			{
				rb2d.AddForce(new Vector2(100, 200));
			}
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












