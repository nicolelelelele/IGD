using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue2 : MonoBehaviour {

	private int lineNumber = 1;
	public GameObject text;
	string line1 = "Pssst! I have a secret for you!";
	string line2 = "See that box right there?";
	string line3 = "That's no ordinary box.\nThat's a vent!";
	string line4 = "Stand in front of it and press 'E',\nand see where it takes you!";

	private string line;

	void Start()
	{
		Speak(line1);
	}

	void Update()
	{
		Debug.Log("line " + lineNumber);
		if(lineNumber>4)
		{
			lineNumber=0;
		}
	}

	private void OnTriggerStay2D(Collider2D col)
	{
		
		if(Input.GetKeyUp(KeyCode.K))
		{
			lineNumber++;
			NextLine(lineNumber);
		}
	}

	private void OnTriggerExit2D (Collider2D col)
	{
		lineNumber = 1;
		Speak(line1);
	}

	void NextLine(int lineNumber)
	{
		//for(int i; i < lineNumber; )
		if(lineNumber == 1)
		{
			Speak(line1);
		}
		if(lineNumber == 2)
		{
			Speak(line2);
		}
		if(lineNumber == 3)
		{
			Speak(line3);
		}
		if(lineNumber == 4)
		{
			Speak(line4);
		}
	}

	void Speak(string line)
	{
		text.GetComponent<TextMesh>().text = line;
	}
}
