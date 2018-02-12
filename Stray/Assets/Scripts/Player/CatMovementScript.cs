using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovementScript : MonoBehaviour 
{

public GameObject Player;
public float Speed = 5f;
public bool canControl;

public Rigidbody2D rb2d;
public float jumpHeight;
private bool grounded = true;

//private float distToGround;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();

	}
	
	void FixedUpdate () 
	{

        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;

		if(canControl == true)
    	{
        	float h = Input.GetAxis("Horizontal") * Speed;  
        	Player.transform.Translate(h*Time.deltaTime,0,0);

        	if(grounded == true)
        	{
        		if(Input.GetKeyDown(KeyCode.UpArrow))
        		{
        			rb2d.velocity = new Vector3(0, jumpHeight, 0);
                    grounded = false;
        			Debug.Log (grounded);
        		}
        	}
    	}

	}     
	
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground") 
        { 
                grounded = true; 
                Debug.Log (grounded);
                Debug.Log ("hit ground");
        }
    }
}

















