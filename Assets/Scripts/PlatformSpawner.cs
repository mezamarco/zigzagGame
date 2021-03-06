using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {



	public GameObject platform;  //Gain access to the Prefab Platform
	public GameObject diamond;	//Gain access to the Prefab Diamond


	Vector3 lastPos;		//Last position of the platformspawner

	float sizex;				//to determine where we have to relocate
	float sizez;				//to determine where we have to relocate

	public bool gameOver;	//varible to tell if game is running or not

	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;		//starting at the position of the prefab platform
		sizex = platform.transform.localScale.x;		//get size of the platform , to know how far we should move.

		sizez = platform.transform.localScale.x;		//get size of the platform , to know how far we should move.
		gameOver = false;								//game is running


	}



	public void StartSpawning(){
	
		
		InvokeRepeating ("SpawnPlatforms", 0f, 0.2f); //SpawnPlatforms fucntion is invoked repeatedly every 0.2 seconds 	

	
	}




	// Update is called once per frame
	void Update () {


		if (GameManager.instance.gameOver == true)
			CancelInvoke ("SpawnPlatforms");

	}




	void SpawnPlatforms(){			//function spawns a new platform in the x or z direction

		int rand = Random.Range (0, 7);

		if (rand >= 4) {
			SpawnX ();

		} else if (rand <= 3) {
			SpawnZ ();
		
		}

	
	}



	void SpawnX(){						
		Vector3 pos = lastPos;
		pos.x += sizex;
		lastPos = pos; 
		Instantiate (platform, pos, Quaternion.identity);

		int random = Random.Range (0,4);
		if (random < 1) {
			Instantiate (diamond, new Vector3(pos.x,pos.y +1,pos.z), diamond.transform.rotation);		
		}


	}

	void SpawnZ(){
	
		Vector3 pos = lastPos;
		pos.z += sizez;
		lastPos = pos; 
		Instantiate (platform, pos, Quaternion.identity);

		int random = Random.Range (0,4);
		if (random < 1) {
			Instantiate (diamond, new Vector3(pos.x,pos.y +1,pos.z), diamond.transform.rotation);
		}
			

	}
}
