﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public GameObject tapText;
	public Text score;
	public Text highScore1;
	public Text highScore2;

	public static UiManager instance;

	void Awake(){
	
		if (instance == null) {
			instance = this;
		}
	}



	// Use this for initialization
	void Start () {
		tapText.SetActive (true);
		highScore1.text = "High Score:  " + PlayerPrefs.GetInt ("highScore");

	}


	public void GameStart(){

		tapText.SetActive (false);

		zigzagPanel.GetComponent<Animator> ().Play ("PanelUp");
	
	}


	public void GameOver(){
		score.text = PlayerPrefs.GetInt ("score").ToString();

		highScore2.text = PlayerPrefs.GetInt ("highScore").ToString();

		gameOverPanel.SetActive(true);
	}


	public void Reset(){
	
		SceneManager.LoadScene (0);
	}




	// Update is called once per frame
	void Update () {
	
	}
}
