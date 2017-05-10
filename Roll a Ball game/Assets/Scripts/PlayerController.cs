using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float speed;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	//Update when physics is going to happen
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		rb.AddForce(movement*speed);
	}
}
