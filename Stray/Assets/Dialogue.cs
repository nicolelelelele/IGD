using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	private int lineNumber = 1;
	public GameObject text;
	string line1 = "Hey! Come talk to me!\nUse 'A' and 'D' to move\nand press 'K' to interact...";
	string line2 = "If you want to jump, press 'J'...";
	string line3 = "You can wall climb by jumping\nwhile pushing your character\nagainst the wall...";
	string line4 = "But be careful, you can only jump\nthree times before you'll\nhave to hit the ground again...";
	string line5 = "You can keep an eye on your\njump power with those three bars\nin the top left corner...";
	string line6 = "Press 'SPACE' to attack enemies.\nKeep in mind it might take a few\nhits to take them down...";
	string line7 = "Collect fish to replenish\nyour health...";
	string line8 = "If you need to pause the game,\npress 'ESC'...";
	string line9 = "To access your inventory,\npress 'I'...";
	string line10 = "From there, you can view\nany items you've collected...";
	string line11 = "You can even change your\ncharacter skin someday!...";
	string line12 = "Come back if you need help!";

	private string line;

	void Start()
	{
		Speak(line1);
	}

	void Update()
	{
		Debug.Log("line " + lineNumber);
		if(lineNumber>12)
		{
			lineNumber=0;
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(Input.GetKeyUp(KeyCode.K))
		{
			lineNumber++;
			NextLine(lineNumber);
		}
	}

	void OnTriggerExit2D (Collider2D collider)
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
		if(lineNumber == 5)
		{
			Speak(line5);
		}
		if(lineNumber == 6)
		{
			Speak(line6);
		}
		if(lineNumber == 7)
		{
			Speak(line7);
		}
		if(lineNumber == 8)
		{
			Speak(line8);
		}
		if(lineNumber == 9)
		{
			Speak(line9);
		}
		if(lineNumber == 10)
		{
			Speak(line10);
		}
		if(lineNumber == 11)
		{
			Speak(line11);
		}
		if(lineNumber == 12)
		{
			Speak(line12);
		}
	}

	void Speak(string line)
	{
		text.GetComponent<TextMesh>().text = line;
	}
}
