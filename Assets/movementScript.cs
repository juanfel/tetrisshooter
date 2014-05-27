using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {
	Vector3 movementVector;
	Vector3 currentPos;
	Vector3 nextPos;
	Vector3 min;
	Vector3 max;
	Vector3 minCorner = new Vector3(0,0,1);
	Vector3 maxCorner = new Vector3 (1, 1, 1);
	float speed = 0.4f;
	// Use this for initialization
	void Start () {
		movementVector = new Vector3 ();
		nextPos = new Vector3 ();
		movementVector.z = 0;
	}
	
	// Update is called once per frame
	// Changes direction of movement depending of what button is pressed
	// Also updates the camera
	void Update () {

		movementVector.y = Input.GetAxis ("Vertical");
		movementVector.x = Input.GetAxis ("Horizontal");
		currentPos = transform.position;
		moveToNextPos ();

		movementVector = new Vector3 (0, 0, 0);
	}

	void moveToNextPos()
	{
		min = Camera.main.ViewportToWorldPoint (minCorner);
		max = Camera.main.ViewportToWorldPoint (maxCorner);
		nextPos = movementVector * speed + currentPos;
		nextPos.x = Mathf.Clamp (nextPos.x, min.x, max.x);
		nextPos.y = Mathf.Clamp (nextPos.y, min.y, max.y);
		transform.position = nextPos;

	}
}
