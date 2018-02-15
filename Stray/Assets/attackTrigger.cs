using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour 
{
	public int damage = 10;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.isTrigger != true && collider.CompareTag("Enemy"))
		{
			collider.SendMessageUpwards("Damage", damage);
			Debug.Log("collided w/ Enemy");
		}
	}
	
}
