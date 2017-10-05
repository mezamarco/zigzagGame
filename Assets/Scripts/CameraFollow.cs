using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject ball;     //Camera will follow this gameObject


	public float LerpRate;		//Allows for a smooth camera transition
	public bool gameOver;		//Tell the camera to stop following the ball after Game Over


	Vector3 offset;				//Variable that gives us a constant distance



	// Use this for initialization
	void Start () {
		offset = ball.transform.position - transform.position;					//Constant distance
		gameOver = false;													
	}
	


	// Update is called once per frame
	void Update () {

		if (!gameOver) {										//If game is not over then make the camera follow the ball.
			Follow ();  			
		}
	
	}

	void Follow(){		

		Vector3 pos = transform.position;														//Get camera position and target position
		Vector3 targetPos = ball.transform.position - offset;

		pos = Vector3.Lerp (pos, targetPos, LerpRate * Time.deltaTime);				// Use the Lerp function to make the smooth camera transition and store in the pos variable

		transform.position = pos;													//Take the new position and place it in the position of the camera
	}




}
