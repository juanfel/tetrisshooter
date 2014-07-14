using UnityEngine;
using System.Collections;

public class LivesBehavior : MonoBehaviour {
	int lives = 5;
	public GameObject livesObject;
	GUIText livesText;
	// Use this for initialization
	void Start () {
		livesText = livesObject.GetComponent<GUIText> ();
		livesText.text = "lives: " + lives;
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
		livesText.text = "Lives:" + lives;
	}
}
