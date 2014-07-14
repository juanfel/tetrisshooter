using UnityEngine;
using System.Collections;

public class ScoreBehavior : MonoBehaviour {
	int score = 0;
	public GameObject scoreObject;
	GUIText scoreText;
	// Use this for initialization
	void Start () {
		scoreText = scoreObject.GetComponent<GUIText> ();
		scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void AddScore()
	{
		score += 1;

		scoreText.text ="Score: " + score;
	}
}
