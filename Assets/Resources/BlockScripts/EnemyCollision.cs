﻿using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Nave");
		Debug.Log (player.tag);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("Colision"+coll.gameObject.tag);
		if (coll.gameObject.tag == "Player") {
			player.GetComponent<LivesBehavior>().shipDies();
			Destroy (this.gameObject );
						
		}
		
	}
}
