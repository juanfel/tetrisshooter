using UnityEngine;
using System.Collections;

public class RectilinealBlockMovement : MonoBehaviour {
	float speed = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 curpos = transform.position;
		curpos.x += speed;
		transform.position = curpos;
	}
}
