using UnityEngine;
using System.Collections;

public class RectilinealBlockMovement : MonoBehaviour {
	float speed = 0.2f;
	bool moving = false;
	// Use this for initialization
	void Start () {
	
	}
	public void StartMoving()
	{
		moving = true;
	}
	// Update is called once per frame
	void Update () {
		StartMoving ();
		if (moving) 
		{
			Vector3 curpos = transform.position;
			curpos.x += speed;
			transform.position = curpos;
		}

	}
}
