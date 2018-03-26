using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCounter : MonoBehaviour {

	public GameObject one;
	public GameObject two;
	public GameObject three;

//	public GameObject one;
//	public GameObject two;
//	public GameObject three;

	void Awake()
	{
		AdjustCounter(3);
		one.SetActive(true);
		two.SetActive(true);
		three.SetActive(true);
	}

	void Update()
	{

	}

	public void Counter(int jumpsLeft)
	{
		if(jumpsLeft == 3)
		{
			AdjustCounter(3);
		}
		else if(jumpsLeft == 2)
		{
			AdjustCounter(2);	
		}
		else if(jumpsLeft == 1)
		{
			AdjustCounter(1);	
		}
		else if(jumpsLeft == 0)
		{
			AdjustCounter(0);	
		}
	}

	public void AdjustCounter(int jumpsLeft)
	{

		if(jumpsLeft == 3)
		{
			Debug.Log("THREE LEFT");
			one.SetActive(true);
			two.SetActive(true);
			three.SetActive(true);
		}
		if (jumpsLeft == 2)
		{
			Debug.Log("TWO LEFT");
			one.SetActive(true);
			two.SetActive(true);
			three.SetActive(false);

			//one.enabled = true;
			//two.enabled = true;
			//three.enabled = false;
		}
		if (jumpsLeft == 1)
		{
			Debug.Log("ONE LEFT");
			one.SetActive(true);
			two.SetActive(false);
			three.SetActive(false);

			//one.enabled = true;
			//two.enabled = false;
			//three.enabled = false;
		}
		if (jumpsLeft == 0)
		{
			Debug.Log("ZERO LEFT");
			one.SetActive(false);
			two.SetActive(false);
			three.SetActive(false);

			//one.enabled = false;
			//two.enabled = false;
			//three.enabled = false;
		}
	}
}
