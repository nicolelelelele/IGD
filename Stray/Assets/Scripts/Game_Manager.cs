using System.Collections;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

	public GameObject player;
	public Vector3 playerSpawnLocation;

	void Start()
	{
		Instantiate(player, playerSpawnLocation, Quaternion.identity);
		//Spawn;
	}

	private void Spawn() 
	{
		Instantiate(player, Vector3.zero, Quaternion.identity);
	}
}
