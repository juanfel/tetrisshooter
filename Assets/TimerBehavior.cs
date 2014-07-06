using UnityEngine;
using System.Collections;

public class TimerBehavior : MonoBehaviour {
	
	public float timeRemaining = 1f;
	
	void Start()
	{
		InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
	}
	
	void Update()
	{
		if (timeRemaining == 0)
		{
			this.gameObject.SendMessageUpwards("prepareSpawn");
			timeRemaining = 2;
		}
		

		
	}
	
	void decreaseTimeRemaining()
	{
		timeRemaining -= 1f;
	}
	
	//may not be needed, left it in there
	void prepareSpawn()
	{}
}
