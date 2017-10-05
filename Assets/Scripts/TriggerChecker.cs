using UnityEngine;
using System.Collections;

public class TriggerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider col){				//After the ball passes through our trigger space, then the platform falls down after 0.5 seconds
		if (col.gameObject.tag == "Ball") {    				
			Invoke ("FallDown", 0.5f);
		}
	

	}


	void FallDown(){
	
		GetComponentInParent<Rigidbody> ().useGravity = true;			//To make it the parent platform fall,make gravity true and make kinematic false. 
		GetComponentInParent<Rigidbody> ().isKinematic = false;

		Destroy (transform.parent.gameObject, 2f);						//Destroy Parent platform after 2 seconds.
	
	}




}
