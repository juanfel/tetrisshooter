using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	Vector3 cameraDir;
	float speed = 0.01f;
	// Use this for initialization
	void Start () 
	{
		cameraDir = new Vector3 (1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = transform.position;
		transform.position = cameraDir * speed + currentPos;
	}
}
