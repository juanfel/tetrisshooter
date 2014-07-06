using UnityEngine;
using System.Collections;

public class LivesBehavior : MonoBehaviour {
	int lives = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void shipDies()
	{

		lives -= 1;
		if (lives < 0) 
		{
			lives = 0;
		}
		Debug.Log ("Lives:" + lives);
	}
}
