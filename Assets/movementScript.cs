using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {
	Vector3 movementVector;
	float speed = 0.4f;
	// Use this for initialization
	void Start () {
		movementVector = new Vector3 ();
		movementVector.z = 0;
	}
	
	// Update is called once per frame
	// Changes direction of movement depending of what button is pressed
	// Also updates the camera
	void Update () {

		movementVector.y = Input.GetAxis ("Vertical");
		movementVector.x = Input.GetAxis ("Horizontal");
		Vector3 currentPos = transform.position;
		transform.position = movementVector * speed + currentPos;
		movementVector = new Vector3 (0, 0, 0);
	}
	void FixedUpdate(){

		}
}
