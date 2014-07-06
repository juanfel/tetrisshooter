using UnityEngine;
using System.Collections;

public class ScoreBehavior : MonoBehaviour {
	int score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddScore()
	{
		score += 1;
		Debug.Log ("Score" + score);
	}
}
