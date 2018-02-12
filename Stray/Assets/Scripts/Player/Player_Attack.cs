using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour 
{

	public Rigidbody2D hammer;
	public float hammerReturnForceMagnitude;
	public float hammerShootForceMagnitude;

	private Vector3 _dir;
	
	
	void Update () 
	{
		//hammer.AddForce(Vector3.Normalize(transform.position - hammer.transform.position) * hammerReturnForceMagnitude);

		_dir = Vector3.zero;

		if (Input.GetKey(KeyCode.A))
		{
			_dir += Vector3.right * -1;
		}	
		if (Input.GetKey(KeyCode.D))
		{
			_dir += Vector3.right;
		}
		if (Input.GetKey(KeyCode.W))
		{
			_dir += Vector3.up;
		}
		if (Input.GetKey(KeyCode.A))
		{
			_dir += Vector3.up * -1;
		}

		_dir = Vector3.Normalize(_dir);

		if (Input.GetKeyDown(KeyCode.K))
		{
			hammer.AddForce(_dir * hammerShootForceMagnitude, ForceMode2D.Impulse);
		}
	}
}
