using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {


	public GameObject particle;


	[SerializeField]
	public float speed;

	bool started;
	public bool gameOver;
	Rigidbody rb;

	void Awake (){
		rb = GetComponent<Rigidbody> (); 
	}

	// Use this for initialization
	void Start () {
		started = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!started) {
			if (Input.GetMouseButton (0)) {
				rb.velocity = new Vector3 (speed,0,0);
				started = true;

				GameManager.instance.GameStart ();
			}
		}

		Debug.DrawRay (transform.position, Vector3.down, Color.red);

		if(!Physics.Raycast (transform.position, Vector3.down, 1f)) 
		{
			gameOver = true;
			rb.velocity = new Vector3 (0, -45f, 0);
			Camera.main.GetComponent<CameraFollow> ().gameOver = true;
			Destroy (gameObject, 0.6f);

			GameManager.instance.GameOver ();

		}

		if (Input.GetMouseButtonDown (0) && !gameOver) {
			SwitchDirection ();
		}

	}


	void SwitchDirection(){
	
		if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}else if (rb.velocity.z > 0 ){
			rb.velocity = new Vector3 (speed, 0, 0);
		}
	
	}




	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Diamond") {

			GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject; //instantiate and save as GameObject at the same time.
			Destroy (col.gameObject);
			Destroy (part, 1f);
		}
	}

}
