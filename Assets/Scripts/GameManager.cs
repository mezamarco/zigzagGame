using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver;

	void Awake(){
	
		if(instance == null)
		{ 
			instance = this;
		}
	
	}



	// Use this for initialization
	void Start () {
	
		gameOver = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void GameStart(){
	
		UiManager.instance.GameStart ();
		ScoreManager.instance.StartScore();
		GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner> ().StartSpawning ();
	}
	public void GameOver(){
	
		UiManager.instance.GameOver ();
		ScoreManager.instance.StopScore();
		gameOver = true;
	}


}
