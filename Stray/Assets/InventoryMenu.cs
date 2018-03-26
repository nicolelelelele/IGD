using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour {

	public GameObject inventoryUI;
	public GameObject itemUI;
	//public GameObject note1;
	//public GameObject audio1;
	//public GameObject photo1;

	public static bool gamePaused = false;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			Debug.Log("inventory");
			if(gamePaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		inventoryUI.SetActive(false);
		itemUI.SetActive(false);
		Time.timeScale = 1f;
		gamePaused = false;
	}

	public void Pause()
	{
		inventoryUI.SetActive(true);
		itemUI.SetActive(false);
		Time.timeScale = 0f;
		gamePaused = true;
	}

	public void clickItem(GameObject buttonName)
	{
		inventoryUI.SetActive(false);
		itemUI.SetActive(true);
		buttonName.SetActive(true);
	}

	public void exitItem(GameObject buttonName)
	{
		inventoryUI.SetActive(true);
		itemUI.SetActive(false);
		buttonName.SetActive(false);
		Time.timeScale = 0f;
		gamePaused = true;
	}

}
