using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour 
{

	private Rigidbody2D _myRB2D;

	private void Start()
	{
		_myRB2D = GetComponent<Rigidbody2D>();
	}	

	public void MoveLeft()
	{
		_myRB2D.AddForce(Vector3.right * -15);
	}

	public void MoveRight()
	{
		_myRB2D.AddForce(Vector3.right * 15);
	}

	public void Jump()
	{
		_myRB2D.AddForce(Vector3.up * 20, ForceMode2D.Impulse);
	}
	
	
}
