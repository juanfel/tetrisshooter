using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (0, 1,true);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("Colision"+coll.gameObject.tag);
		if (coll.gameObject.tag == "Enemigo") {
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
						
		}
		
	}
}
