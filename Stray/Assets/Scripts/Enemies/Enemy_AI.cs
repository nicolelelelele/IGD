using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour 
{

	public Enemy_Movement move;

	private float _timer;

	private bool moveLeft;

	//Function that will do switching ffor me
	public void AISwitch(int caseSwitch)
	{
		// The case number
		//int caseSwitch = 1;

		// Case number is passed to switch and it passes 1
		switch (caseSwitch)
		{
			case 1:
				moveLeft = true;
				break;
			case 2:
				moveLeft = false;
				break;
			default:
				moveLeft = true;
				break;
		}
	}



	private void Update()
	{
		_timer += Time.deltaTime;

		/*if (_timer >= 2) 
		{
			_timer -= 2;
			if (something) 
			{
				AISwitch(1)
			}
		}*/


		if (_timer <= 1)
		{
			AISwitch(1);
		}
		if (_timer > 1 && _timer <= 2)
		{
			AISwitch(2);
		}
		if (_timer >= 2)
		{
			_timer -= 2;
		}
		if (moveLeft == true)
		{
			move.MoveLeft();
		}
		else
		{
			move.MoveRight();
		}
	}

}
